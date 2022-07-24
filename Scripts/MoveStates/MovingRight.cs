using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
class MovingRight: Moving, IMoverState
{
    public void Stop( Hero hero ) 
    { 
        Debug.Log("стоим");
        hero.SetMoveState( new Stoping() );
    }
    
    public void TransitionMovingLeft( Hero hero ) 
    { 
    }
    public void TransitionMovingRight( Hero hero ) 
    { 
    }
    
     public void Move( Hero hero, Rigidbody2D rigidbody, Vector3 gravityVector )
    {
         Debug.Log($"идем вправо" );
         base.Move(hero, rigidbody, gravityVector, 1);
    }

}

