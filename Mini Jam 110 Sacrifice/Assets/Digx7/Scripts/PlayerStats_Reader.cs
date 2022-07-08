using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats_Reader : MonoBehaviour
{
  public PlayerStats_SO Stats;
  //public UnityEvent Response;

  public IntEvent moveSpeedUpdated;

  public IntEvent currentHealthUpdated;
  public IntEvent resistanceUpdated;

  public UnityEvent patternUpdated;
  public IntEvent bulletSpeedUpdated;
  public IntEvent bulletRateUpdated;

  private void OnEnable()
  { Stats.RegisterListener(this); }

  private void OnDisable()
  { Stats.UnregisterListener(this); }

  public void OnEventRaised()
  { //Response.Invoke();
  }


  public void OnMoveSpeedUpdate(int input){
    moveSpeedUpdated.Invoke(input);
  }

  public void OnCurrentHealthUpdate(int input){
    currentHealthUpdated.Invoke(input);
  }

  public void OnResistanceUpdate(int input){
    resistanceUpdated.Invoke(input);
  }

  public void OnPatternUpdate(){
    patternUpdated.Invoke();
  }

  public void OnBulletSpeedUpdate(int input){
    bulletSpeedUpdated.Invoke(input);
  }

  public void OnBulletRateUpdate(int input){
    bulletRateUpdated.Invoke(input);
  }


  }
