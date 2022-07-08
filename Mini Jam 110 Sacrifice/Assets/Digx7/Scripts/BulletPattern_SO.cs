using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPattern", menuName = "ScriptableObjects/BulletPattern/Pattern", order = 1)]
public class BulletPattern_SO : ScriptableObject
{
    public List<BulletPattern_Node> nodes;
}
