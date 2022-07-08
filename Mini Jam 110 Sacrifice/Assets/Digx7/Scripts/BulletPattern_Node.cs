using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNode", menuName = "ScriptableObjects/BulletPattern/Node", order = 1)]
public class BulletPattern_Node : ScriptableObject
{
    public GameObject bullet;

    public Vector2 SpawnLocation;
    public Quaternion Rotation;
}
