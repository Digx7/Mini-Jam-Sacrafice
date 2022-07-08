using System.Collections;
using NUnit.Framework;
using Unity.Burst.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.Collections;
using Unity.Burst;
using Unity.Jobs;

[TestFixture]
[UnityPlatform(RuntimePlatform.WindowsEditor, RuntimePlatform.OSXEditor)]
public class BurstInspectorGUITests
{
    [UnityTest]
    public IEnumerator TestInspectorOpenDuringDomainReloadDoesNotLogErrors()
    {
        // Show Inspector window
        EditorWindow.GetWindow<BurstInspectorGUI>().Show();

        Assert.IsTrue(EditorWindow.HasOpenInstances<BurstInspectorGUI>());

        // Ask for domain reload
        EditorUtility.RequestScriptReload();

        // Wait for the domain reload to be completed
        yield return new WaitForDomainReload();

        Assert.IsTrue(EditorWindow.HasOpenInstances<BurstInspectorGUI>());

        // Hide Inspector window
        EditorWindow.GetWindow<BurstInspectorGUI>().Close();

        Assert.IsFalse(EditorWindow.HasOpenInstances<BurstInspectorGUI>());
    }

    [UnityTest]
    public IEnumerator FontStyleDuringDomainReloadTest()
    {
        EditorWindow.GetWindow<BurstInspectorGUI>();

        // Enter play mod
        yield return new EnterPlayMode();

        // Exit play mode
        yield return new ExitPlayMode();

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Assert.AreEqual("Consolas", EditorWindow.GetWindow<BurstInspectorGUI>()._font.name);
        }
        else
        {
            Assert.AreEqual("Courier", EditorWindow.GetWindow<BurstInspectorGUI>()._font.name);
        }
        EditorWindow.GetWindow<BurstInspectorGUI>().Close();
    }

    [UnityTest]
    public IEnumerator InspectorStallingLoadTest()
    {
        var win = EditorWindow.GetWindow<BurstInspectorGUI>();

        // Skip frames untill inspector is initialized
        yield return new WaitUntil(() => EditorWindow.GetWindow<BurstInspectorGUI>()._initialized);

        // Need to choose target to actually trigger the bug.
        win._treeView.TrySelectByDisplayName("BurstInspectorGUITests.MyJob - (IJob)");

        // Send event CTRL+f
        if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
        {
            win.SendEvent(Event.KeyboardEvent("%f"));
        }
        else
        {
            win.SendEvent(Event.KeyboardEvent("^f"));
        }

        // Go one frame ahead
        yield return null;

        // Send events for ..
        win.SendEvent(Event.KeyboardEvent("."));
        win.SendEvent(Event.KeyboardEvent("."));

        // Send RequestScriptReload to try and trigger the bug
        EditorUtility.RequestScriptReload();

        // Check to see if it is initialized !!
        yield return new WaitForDomainReload();

        win = EditorWindow.GetWindow<BurstInspectorGUI>();

        Assert.IsTrue(win._initialized, "BurstInspector did not initialize properly after script reload");

        win.Close();
    }


    //[UnityTest]
    public IEnumerator BranchHoverTest()
    {
        EditorWindow.GetWindow<BurstInspectorGUI>();

        // Make sure window is actually initialized before continuing.
        EditorUtility.RequestScriptReload();    // Ask for domain reload
        yield return new WaitForDomainReload(); // Wait for the domain reload to be completed


        var window = EditorWindow.GetWindow<BurstInspectorGUI>();

        // Selecting a specific assembly.
        window._treeView.TrySelectByDisplayName("BurstInspectorGUITests.MyJob - (IJob)");

        // Sending event to set the displayname, to avoid it resetting _scrollPos because of target change.
        window.SendEvent(new Event() { type = EventType.Repaint, mousePosition = new Vector2(window.position.width / 2f, window.position.height / 2f) });

        // Setting up for the test.
        // Finding an edge:
        int dstBlockIdx = -1;
        int srcBlockIdx = -1;
        int line = -1;
        for (int idx = 0; idx < window._burstDisassembler.Blocks.Count; idx++)
        {
            var block = window._burstDisassembler.Blocks[idx];
            if (block.Edges != null)
            {
                foreach (var edge in block.Edges)
                {
                    if (edge.Kind == BurstDisassembler.AsmEdgeKind.OutBound)
                    {
                        dstBlockIdx = edge.LineRef.BlockIndex;
                        line = window._textArea._blockLine[dstBlockIdx];
                        if ((dstBlockIdx == idx + 1 && edge.LineRef.LineIndex == 0)) // pointing to next line
                        {
                            continue;
                        }
                        srcBlockIdx = idx;
                        break;
                    }
                }
                if (srcBlockIdx != -1)
                {
                    break;
                }
            }
        }
        if (srcBlockIdx == -1)
        {
            window.Close();
            throw new System.Exception("No edges present in assembly for \"BurstInspectorGUITests.MyJob - (IJob)\"");
        }

        float dist = line * window._textArea.fontHeight;

        float x = (window.position.width - (window._inspectorView.width + BurstInspectorGUI._scrollbarThickness)) + window._textArea.horizontalPad - (4 + window._textArea.fontWidth);

        // setting _ScrollPos so end of arrow is at bottom of screen, to make sure there is actually room for the scrolling.
        window._scrollPos = new Vector2(0, dist - window._inspectorView.height * 0.95f);

        // Setting mousePos to bottom of inspector view.
        float topOfInspectorToBranchArrow = window._buttonOverlapInspectorView + 66.5f;//66.5f is the size of space over the treeview of different jobs.

        var mousePos = new Vector2(x, topOfInspectorToBranchArrow + LongTextArea.regLineThickness + window._inspectorView.height * 0.95f);

        window.SendEvent(new Event() { type = EventType.MouseUp, mousePosition = mousePos });
        var branch = window._textArea._hoveredBranch;

        // Close window to avoid it sending more events
        window.Close();

        Assert.AreNotEqual(branch, default(LongTextArea.Branch));
        Assert.AreEqual(srcBlockIdx, branch.Edge.OriginRef.BlockIndex);
        Assert.AreEqual(dstBlockIdx, branch.Edge.LineRef.BlockIndex);
    }

    [BurstCompile]
    private struct MyJob : IJob
    {
        [ReadOnly]
        public NativeArray<float> Input;

        [WriteOnly]
        public NativeArray<float> Output;

        public void Execute()
        {
            float result = 0.0f;
            for (int i = 0; i < Input.Length; i++)
            {
                result += Input[i];
            }
            Output[0] = result;
        }
    }
}
