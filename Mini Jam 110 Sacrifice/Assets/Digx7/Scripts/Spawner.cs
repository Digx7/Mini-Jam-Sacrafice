using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public Vector2 spawnLocation;
    public bool setSpawnLocationToSameAsThis;

    public void Start(){
      if(setSpawnLocationToSameAsThis) spawnLocation = transform.position;
    }

    public void Spawn(){
      Instantiate(prefabs[Random.Range(0,prefabs.Count - 1)], spawnLocation, Quaternion.identity);
    }
}
