using System;
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
    
    public void Jump( Hero hero, Rigidbody2D rigidbody )
    {
      
      // SetPositionRigidbody( hero, rigidbody );
       SetPositionRigidbody( hero, hero.Rigidbody );

       if( _deltaJump >= _heightJump )
       {
         rigidbody.gravityScale = 5f;
         OnFinishJump?.Invoke( hero );

       }

    }
}
