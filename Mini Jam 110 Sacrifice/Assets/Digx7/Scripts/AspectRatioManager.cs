using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioManager : MonoBehaviour
{
  public Vector2 ratio;

    public void Start()
    {
      SetRatio(ratio.x, ratio.y);
    }

    public void SetRatio(float w, float h)
    {
      if ((((float)Screen.width) / ((float)Screen.height)) > w / h)
      {
          Screen.SetResolution((int)(((float)Screen.height) * (w / h)), Screen.height, true);
      }
      else
      {
          Screen.SetResolution(Screen.width, (int)(((float)Screen.width) * (h / w)), true);
      }
    }
}
