using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test_Input : MonoBehaviour
{
    public Vector2Event wasd;
    public Vector2 input;

    public UnityEvent space;

    public void Update(){
      if (Input.GetKey("w")) input.y= 1;
      else if (Input.GetKey("s")) input.y= -1;
      else input.y=0;

      if (Input.GetKey("d")) input.x= 1;
      else if (Input.GetKey("a")) input.x= -1;
      else input.x= 0;

      wasd.Invoke(input);

      if (Input.GetKey("space")) space.Invoke();
    }
}
