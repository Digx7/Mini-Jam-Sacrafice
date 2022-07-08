using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInt", menuName = "ScriptableObjects/Data/Int", order = 1)]
public class Int_SO : ScriptableObject
{
    public int data;

    public void SetData(int input){
      data=input;
    }

    public int GetData(){
      return data;
    }
}
