using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff_Manager : MonoBehaviour
{
    public Debuff_SO debuff;
    public PlayerStats_SO statsToChange;

    public void triggerDebuff(){
      statsToChange.updateMoveSpeed(debuff.changeToMoveSpeed);
      statsToChange.updateCurrentHealth(debuff.changeToCurrentHealth);
      statsToChange.updateBulletSpeed(debuff.changeToBulletSpeed);
      statsToChange.updateBulletRate(debuff.changeToBulletRate);

      if (debuff.newPattern != null) statsToChange.setPattern(debuff.newPattern);
    }
}
