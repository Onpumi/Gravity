using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving
{
    public Vector3 VectorMove { get; private set; }
    public Vector3 TargetPosition { get; private set; }
    public  void Move( Hero hero, Rigidbody2D rigidbody, Vector3 gravityVector, int directionMove )
  {
       VectorMove = new Vector3(-gravityVector.y, gravityVector.x, 0);	
       VectorMove.Normalize();
       TargetPosition = directionMove * VectorMove * Time.deltaTime * hero.Speed;

       hero.SetFaceDirection( directionMove );

     if( hero.IsGround == true )
     {
       rigidbody.MovePosition( hero.transform.position + TargetPosition );
     }
     else 
     {
        rigidbody.AddForce( TargetPosition * 50f, ForceMode2D.Force);
     }
  }


}