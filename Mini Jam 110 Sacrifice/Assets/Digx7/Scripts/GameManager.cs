using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStats_SO startingStats;
    public PlayerStats_SO runningStats;

    public void Start(){
      runningStats.setAllStats(startingStats);
    }
}
