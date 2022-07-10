using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtRotation : MonoBehaviour
{
    public Postition_SO target;
    public Transform objectToRotate;

    public void LateUpdate(){
      if(target != null) {
        /*

        Vector3 relativePos = new Vector3();
        //relativePos.x = target.position.x - objectToRotate.position.x;
        //relativePos.y = target.position.y - objectToRotate.position.y;

        relativePos.x = objectToRotate.position.x - target.position.x;
        relativePos.y = objectToRotate.position.y - target.position.y;

       // the second argument, upwards, defaults to Vector3.up
       Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
       objectToRotate.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
       */

       Vector3 relativePos = new Vector3();
       relativePos.x = target.position.x - objectToRotate.position.x;
       relativePos.y = target.position.y - objectToRotate.position.y;

       objectToRotate.right = relativePos;

      }
    }
}
