using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Updater : MonoBehaviour
{
    public Postition_SO data;

    public GameObject target;

    public void FixedUpdate(){
      data.SetPosition(target.transform.position);
    }
}
