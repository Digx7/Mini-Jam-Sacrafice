using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSetup : MonoBehaviour
{
    public PlayerStats_SO stats;

    public Health health;

    public void Start(){
      health.SetMaxHealth(stats.getCurrentHealth());
      health.RefillHealth();
    }
}
