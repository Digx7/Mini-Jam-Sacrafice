using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject target;

    public void DestroyObject_(){
      Destroy(target);
    }
}
