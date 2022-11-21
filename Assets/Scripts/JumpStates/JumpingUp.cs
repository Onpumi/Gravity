using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingUp : Jumping, IJumpingState
{
    public Vector3 startPosition {get; private set; }
    public Vector3 targetPosition {get; private set; }
    public event Action<Hero> OnFinishJump;

    public JumpingUp()
    {
        OnFinishJump += NextTransition;
    }
    public void StopJump( Hero hero )
    {
        Debug.Log("Нет прыжка");
    }
    public void TransitionMoveUp( Hero hero )
    {
        Debug.Log("начинаем прыгать вверх");
    }
    public void TransitionMoveDown( Hero hero )
    {
        Debug.Log("Падаем");
    }
    private void NextTransition( Hero hero )
    {
        hero.SetJumpState(new JumpingDown());
    }
    
    public void Jump( AnimationCurve curve, Hero hero, Rigidbody2D rigidbody, bool isCanCurveAnimation )
    {

        if( isCanCurveAnimation == false )
        {
            hero.SetJumpState(new JumpingDown());
        }

       SetPositionRigidbody( hero, curve, rigidbody, isCanCurveAnimation );

     /*
       if( CurrentTime >= curve.keys[curve.length-1].time )
       {
         CurrentTime = 0;
         OnFinishJump?.Invoke( hero );
       }
       */
       if( _deltaJump >= _heightJump )
       {
         rigidbody.gravityScale = 5f;
         OnFinishJump?.Invoke( hero );
       }
       //rigidbody.position.y  

        
    }
}
