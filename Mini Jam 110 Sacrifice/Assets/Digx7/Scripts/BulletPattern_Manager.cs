using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern_Manager : MonoBehaviour
{
    public BulletPattern_SO pattern;
    public GameObject origin;

    public bool useLocal = false;

    public void SetPattern(BulletPattern_SO input){
      pattern = input;
    }

    public void Fire(){
      for(int i = 0; i < pattern.nodes.Count; ++i){
        BulletPattern_Node node = pattern.nodes[i];

        Vector2 location = node.SpawnLocation;
        if(!useLocal){
          location.x += origin.transform.position.x;
          location.y += origin.transform.position.y;

           Instantiate(node.bullet, location, node.Rotation);
        }
        else{
          GameObject bullet = Instantiate(node.bullet, origin.transform, false);
          bullet.transform.rotation = node.Rotation;
          bullet.transform.SetParent(null, true);
        }
      }
    }
}
