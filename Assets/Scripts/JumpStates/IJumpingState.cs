using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public interface IJumpingState 
{
    public Vector3 startPosition {get;  }
    public Vector3 targetPosition {get; }
    void StopJump( Hero hero );
    void TransitionMoveUp( Hero hero );
    void TransitionMoveDown( Hero hero );
    void Jump( AnimationCurve curve, Hero hero, Rigidbody2D rigidbody, bool isCanCurveAnimation );
}




