using UnityEngine;

public class StopingJump : IJumpingState
{
    public Vector3 startPosition {get; private set; }
    public Vector3 targetPosition {get; private set; }

    public void StopJump( Hero hero ) { }
    public void TransitionMoveUp( Hero hero )
    {
        Debug.Log("начинаем прыгать вверх");
        hero.SetJumpState(new JumpingUp());
    }
    public void TransitionMoveDown( Hero hero ) { }
    public void Jump( Hero hero, Rigidbody2D rigidbody )
    {
    }
}
