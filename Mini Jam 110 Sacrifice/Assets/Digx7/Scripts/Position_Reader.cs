using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Reader : MonoBehaviour
{
    public Postition_SO data;

    public Vector2Event info;

    public void FixedUpdate(){
      info.Invoke(data.position);
    }
}
