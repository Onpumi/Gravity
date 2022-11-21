using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping
{
    public float CurrentTime  { get; protected set; } 
    
    public float TimeLeft => _totalTime - CurrentTime;
    public float PositionJump {get; private set; }
    protected float _totalTime = 0;
    protected float _currentPosition;
    private Vector3 _targetPosition;
    private float _height = 1f;
    private float _duration = 1f;
    private float _startHeight;
    private Vector2 _startPosition;
    protected float _heightJump = 10f;
    protected float _deltaJump = 0f;
    protected float _startPositionY;
    

    public Jumping()
    {
        CurrentTime = 0;
    }

     protected void SetPositionRigidbody( Hero hero, AnimationCurve curve, Rigidbody2D rigidbody, bool isCanCurveAnimation )
    {
       

        if( CurrentTime == 0 )
        {
            _startHeight = rigidbody.position.y;
            PositionJump = 0;
            _currentPosition = 0;
            
        }

        if( _deltaJump == 0f)
        {
            _startPositionY = rigidbody.position.y;
        }

         PositionJump = curve.Evaluate(CurrentTime /_duration) * _height;
        _currentPosition = _startHeight + PositionJump;
         CurrentTime += Time.deltaTime;
    
    //    rigidbody.position = new Vector2(rigidbody.position.x, _currentPosition);
             rigidbody.gravityScale = 0f;
            _deltaJump += 20f * Time.fixedDeltaTime;
              rigidbody.position = new Vector2(rigidbody.position.x, _startPositionY + _deltaJump);
      
    }
    


}
