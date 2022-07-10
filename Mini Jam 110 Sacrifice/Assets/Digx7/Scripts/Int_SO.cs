using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInt", menuName = "ScriptableObjects/Data/Int", order = 1)]
public class Int_SO : ScriptableObject
{
    public int data;
    public bool startAtZero=false;

    private List<Int_Listener> listeners =
  		new List<Int_Listener>();

    public void Awake(){
      if(startAtZero) data=0;
    }

    public void SetData(int input){
      data=input;
      //checkIfDateIsZero();
    }

    public void UpdateData(int input){
      data+=input;
      checkIfDateIsZero();
    }

    public int GetData(){
      return data;
    }

    private void checkIfDateIsZero(){
      if(data==0){
        for(int i = listeners.Count -1; i >= 0; i--)
        listeners[i].OnDataHitZero();
      }
    }

    public void RegisterListener(Int_Listener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(Int_Listener listener)
    { listeners.Remove(listener); }
}
