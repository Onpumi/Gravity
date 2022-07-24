using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMoverState 
{
    void Stop(Hero hero);
    void TransitionMovingLeft(Hero hero);
    void TransitionMovingRight(Hero hero);
    void Move( Hero hero, Rigidbody2D rigidbody, Vector3 gravityVector );
}


