using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 direction;

    public enum MovementMode {velocity, force};
    public MovementMode mode;

    public void FixedUpdate(){
      if (mode == MovementMode.velocity)Move_Velocity(direction);
      else if(mode == MovementMode.force)Move_AddForce(direction);
    }

    public void SetDirection(Vector2 input){
      direction = input;
    }

    public void DircetionIsTowardPos(Vector2 input){
      Vector2 currentPos = transform.position;
      direction = (input - currentPos).normalized;
    }

    private void Move_AddForce(Vector2 input){
      rb.AddRelativeForce(input * speed);
    }

    private void Move_Velocity(Vector2 input){
      rb.velocity = input * speed;
    }
}
