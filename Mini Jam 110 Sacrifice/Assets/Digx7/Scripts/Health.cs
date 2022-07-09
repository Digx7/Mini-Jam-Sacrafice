using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int resistance;

    public IntEvent healthChanged;
    public UnityEvent hasDied;

    public void Start(){
      healthChanged.Invoke(currentHealth);
    }

    public void SetResistance(int input){
      resistance = input;
    }

    public void SetMaxHealth(int input){
      maxHealth = input;
    }

    public void RefillHealth(){
      currentHealth = maxHealth;

      healthChanged.Invoke(currentHealth);
    }

    public void Damage(int amount){
      amount -= resistance;
      if(amount <= 0) amount++;
      currentHealth -= amount;

      healthChanged.Invoke(currentHealth);

      checkIfDead();
    }

    public void Heal(int amount){
      currentHealth += amount;
      if(currentHealth > maxHealth) currentHealth = maxHealth;

      healthChanged.Invoke(currentHealth);
    }

    public void checkIfDead(){
      if(currentHealth <= 0) hasDied.Invoke();
    }
}
