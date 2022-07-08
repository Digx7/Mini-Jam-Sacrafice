using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timeToWait;
    public bool loop;

    public UnityEvent timerFinish;

    public void Start(){
      StartCoroutine("Wait");
    }

    public void SetTimeToWait(int input){
      timeToWait = input;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToWait);
        timerFinish.Invoke();
        if (loop) StartCoroutine("Wait");
    }
}
