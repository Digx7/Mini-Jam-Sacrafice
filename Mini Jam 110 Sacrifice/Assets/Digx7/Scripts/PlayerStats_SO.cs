using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStat", menuName = "ScriptableObjects/Data/PlayerStats", order = 1)]
public class PlayerStats_SO : ScriptableObject
{
  public int moveSpeed;

  public int currentHealth;
  public int resistance;

  public BulletPattern_SO pattern;
  public int bulletSpeed;
  public int bulletRate;

  private List<PlayerStats_Reader> listeners =
		new List<PlayerStats_Reader>();

  public void setAllStats(PlayerStats_SO other){
    setMoveSpeed(other.getMoveSpeed());
    setCurrentHealth(other.getCurrentHealth());
    setPattern(other.getPattern());
    setBulletSpeed(other.getBulletSpeed());
    setBulletRate(other.getBulletRate());
  }

  public void setMoveSpeed(int input){
    moveSpeed = input;
    for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnMoveSpeedUpdate(moveSpeed);
  }
  public void updateMoveSpeed(int input){
    moveSpeed += input;
    for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnMoveSpeedUpdate(moveSpeed);
  }
  public int getMoveSpeed(){
    return moveSpeed;
  }

  public void setCurrentHealth(int input){
    currentHealth = input;
    for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnCurrentHealthUpdate(currentHealth);
  }
  public void updateCurrentHealth(int input){
    currentHealth += input;
    for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnCurrentHealthUpdate(currentHealth);
  }
  public int getCurrentHealth(){
    return currentHealth;
  }

  public void setPattern(BulletPattern_SO input){
    pattern = input;
    for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnPatternUpdate(input);
  }
  public BulletPattern_SO getPattern(){
    return pattern;
  }

  public void setBulletSpeed(int input){
    bulletSpeed = input;
    for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnBulletSpeedUpdate(bulletSpeed);
  }
  public void updateBulletSpeed(int input){
    bulletSpeed += input;
    for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnBulletSpeedUpdate(bulletSpeed);
  }
  public int getBulletSpeed(){
    return bulletSpeed;
  }

  public void setBulletRate(int input){
    bulletRate = input;
    for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnBulletRateUpdate(bulletRate);
  }
  public void updateBulletRate(int input){
    bulletRate += input;
    for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnBulletRateUpdate(bulletRate);
  }
  public int getBulletRate(){
    return bulletRate;
  }

  public void Raise()
  {
  	for(int i = listeners.Count -1; i >= 0; i--)
    listeners[i].OnEventRaised();
  }

  public void RegisterListener(PlayerStats_Reader listener)
  { listeners.Add(listener); }

  public void UnregisterListener(PlayerStats_Reader listener)
  { listeners.Remove(listener); }
}
