using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;



public class Hero : MonoBehaviour
{
   [SerializeField] private AnimationCurve _jumpingUp;
   [SerializeField] private AnimationCurve _jumpingStop;
   [SerializeField] private TransitionMoveLeft _buttonLeftRun;
   [SerializeField] private TransitionMoveRight _buttonRightRun;
   [SerializeField] private TransitionJump _buttonJump;
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
   [SerializeField] private Transform _legs;
   [SerializeField] private LayerMask _maskaPlace;
   [SerializeField] private LayerMask _groundMask;
   IMoverState _typeMove = new Stoping();
   IJumpingState _stateJumping = new StopingJump();
   public Sprite Sprite { get; private set; }
	private bool _faceDirectionRight;
	private bool _isGround = true;
   public bool IsGround => _isGround;
   public event Action<Collision2D> ContactGround;
   public int FaceDirection =>  (_faceDirectionRight) ? (1) : (-1);
   public float Speed  { get => _speed; }
   public float JumpForce { get => _jumpForce; }
   private Rigidbody2D _rigidbody;
   private CircleCollider2D _collider;
   private float _directionX = 0;
   private bool _isCanCurveAnimation = true;
   public bool IsCanJump => _isCanCurveAnimation;
   Vector3 _targetPosition = Vector3.zero;
   AnimationCurve curve;

   private void Awake()
   {
      Sprite = GetComponent<SpriteRenderer>().sprite;
      _rigidbody = GetComponent<Rigidbody2D>();
      _collider = GetComponent<CircleCollider2D>();
      curve = _jumpingUp;
   }


	private void OnCollisionEnter2D( Collision2D collision ) 
   {
     if( collision.collider.TryGetComponent(out Platform platform) ) 
     { 
      _stateJumping = new JumpingDown();
      _rigidbody.velocity = Vector2.zero;
     }
   }

       private void OnCollisionStay2D( Collision2D coll )
     {
	     if( coll.collider.tag == "Green") 
        {
        // ContactGround.Invoke(coll);
        }
     }

       private void OnCollisionExit2D(Collision2D coll)
    {
	     if(coll.collider.tag == "Green")  
        {
          _isGround = false;
        }
    }

     bool isNotIdentityFaceDirection( float x1, float x2 )  => ( (x1 < 0) && (x2 > 0)  || (x1 > 0) && (x2 < 0) );
     public void SetFaceDirection( int direction )
   {
      _faceDirectionRight = (direction > 0) ? (true) : (false);
	    Vector3 bufferLocalScale = transform.localScale ;
       bufferLocalScale.x = (isNotIdentityFaceDirection( transform.localScale.x, FaceDirection )) ? (-bufferLocalScale.x) : (bufferLocalScale.x);
       transform.localScale = bufferLocalScale;
   }

  private void OnEnable()
    {
       _buttonLeftRun.OnClickMoveLeft += TransitionMovingLeft;
       _buttonRightRun.OnClickMoveRight += TransitionMovingRight;
       _buttonLeftRun.OnUpMoveLeft += StopMove;
       _buttonRightRun.OnUpMoveRight += StopMove;
       _buttonJump.OnClickJump += TransitionMoveUp;
    }

    private void OnDisable()
    {
       _buttonLeftRun.OnClickMoveLeft -= TransitionMovingLeft;
       _buttonRightRun.OnClickMoveRight -= TransitionMovingRight;
       _buttonLeftRun.OnUpMoveLeft -= StopMove;
       _buttonRightRun.OnUpMoveRight -= StopMove;
       _buttonJump.OnClickJump -= TransitionMoveUp;
    }
   public void TransitionMovingLeft()  
    { 
     _targetPosition = new Vector3(-1,0,0) * _speed * Time.fixedDeltaTime;
      _directionX = (float)MoveDirection.LEFT;
    }
   
   public void TransitionMovingRight() 
   {
      _targetPosition = new Vector3(1,0,0) * _speed * Time.fixedDeltaTime;

      _directionX = (float)MoveDirection.RIGHT;

//      _rigidbody.velocity = new Vector2( _targetPosition.x, _rigidbody.velocity.y) * _speed;
       //_rigidbody.velocity = _targetPosition * _speed;
   }

   public void TransitionMoveUp() 
   {
      CheckGround( -Vector2.up );
      if( IsGround )
      {
        _stateJumping.TransitionMoveUp( this );
      }
   }

   public void Stop() => _typeMove.Stop( this );

   public void Move( Vector3 gravityVector ) => _typeMove.Move( this, _rigidbody, gravityVector );

   public void SetMoveState( IMoverState state ) => _typeMove = state;
   public void SetJumpState( IJumpingState state ) => _stateJumping = state;



   private void StopMove() 
   {
      _targetPosition = Vector3.zero;
       Stop();
       _directionX = (float)MoveDirection.STOP;
   }

   public void Jump()
   {
      if ( _stateJumping.GetType() != typeof(StopingJump)) 
      { 
         _isGround = true;
      }
    //    if ( _isCanCurveAnimation == false && IsGround == false ) 
      //  { 
        // _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_rigidbody.velocity.y);
//          return;
  //      }
       _stateJumping.Jump( _jumpingUp, this, _rigidbody, _isCanCurveAnimation );
      
       //_isGround = false;
   }

 
   public bool CheckGround( Vector2 rayDirection )
   {
       return _isGround = (Physics2D.Raycast( _legs.position + (Vector3)rayDirection.normalized * _collider.radius, rayDirection, 0.5f, _groundMask).collider != null);
   }


   private void Update()
   {

       if( Input.GetAxis("Cancel") > 0 )
 	  {
	    Application.Quit();
	  }
   }


   public void EnableCurveAnimation()
   {
      _isCanCurveAnimation = true;
   }
   private void FixedUpdate()
   {
        _rigidbody.velocity = new Vector2( _directionX * _speed * Time.fixedDeltaTime, _rigidbody.velocity.y);
   }
}

public enum MoveDirection
{
   LEFT = -1,
   RIGHT = 1,
   STOP = 0
}