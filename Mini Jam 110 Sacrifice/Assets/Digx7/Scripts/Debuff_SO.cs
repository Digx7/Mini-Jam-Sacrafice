using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDebuff", menuName = "ScriptableObjects/Debuff", order = 1)]
public class Debuff_SO : ScriptableObject
{
    public int changeToMoveSpeed;

    public int changeToCurrentHealth;
    public int changeToResistance;

    public BulletPattern_SO newPattern;
    public int changeToBulletSpeed;
    public int changeToBulletRate;
}
