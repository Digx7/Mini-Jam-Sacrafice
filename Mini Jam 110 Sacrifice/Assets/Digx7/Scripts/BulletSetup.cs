using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetup : MonoBehaviour
{
    public PlayerStats_SO stats;
    public Movement movement;

    public void Start(){
      movement.SetSpeed(stats.getBulletSpeed());
    }
}
