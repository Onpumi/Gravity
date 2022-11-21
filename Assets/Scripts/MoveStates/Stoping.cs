using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class Stoping: IMoverState
{
    public int Direction { get; private set; }
    public Vector3 DirectionMove { get; private set; }
    public Vector3 TargetPosition { get; private set; }

   public void Stop( Hero hero ) 
   { 
      Debug.Log("стоим");
   }

   
   public void TransitionMovingLeft( Hero hero )
   {
      hero.SetMoveState( new MovingLeft() );
   }
   public void TransitionMovingRight( Hero hero )
   {
      hero.SetMoveState( new MovingRight() );
   }

   
    public void Move( Hero hero, Rigidbody2D rigidbody, Vector3 gravityVector )
   {

   }

}
