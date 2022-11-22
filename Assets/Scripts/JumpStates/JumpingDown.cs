using UnityEngine;

public class JumpingDown : IJumpingState
{
    public Vector3 startPosition {get; private set; }
    public Vector3 targetPosition {get; private set; }
    public void StopJump( Hero hero ) { }
    public void TransitionMoveUp( Hero hero ) { }
    public void TransitionMoveDown( Hero hero ) { }
    public void Jump( Hero hero, Rigidbody2D rigidbody )
    {

            hero.CheckGround( -Vector2.up );
            if( hero.IsGround )
            {
                rigidbody.gravityScale = 5f;
                hero.SetJumpState(new StopingJump());
                Debug.Log("упали " + hero.IsGround);
            }
    }
}
