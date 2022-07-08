using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPosition", menuName = "ScriptableObjects/Position", order = 1)]
public class Postition_SO : ScriptableObject
{
    public Vector2 position;

    public void SetPosition(Vector2 input){
      position = input;
    }

    public void SetPosition(Vector3 input){
      position.x = input.x;
      position.y = input.y;
    }
}
