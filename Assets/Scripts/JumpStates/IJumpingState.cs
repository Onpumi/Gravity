using UnityEngine;

 public interface IJumpingState 
{
    public Vector3 startPosition {get;  }
    public Vector3 targetPosition {get; }
    void StopJump( Hero hero );
    void TransitionMoveUp( Hero hero );
    void TransitionMoveDown( Hero hero );
    void Jump( Hero hero, Rigidbody2D rigidbody );
}




