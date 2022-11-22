using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;



public class Hero : MonoBehaviour
{
   [SerializeField] private TransitionMoveLeft _buttonLeftRun;
   [SerializeField] private TransitionMoveRight _buttonRightRun;
   [SerializeField] private TransitionJump _buttonJump;
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
   [SerializeField] private Transform _legs;
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
   private Vector2 _direction;
   public Rigidbody2D Rigidbody=>_rigidbody;

   private void Awake()
   {
      Sprite = GetComponent<SpriteRenderer>().sprite;
      _rigidbody = GetComponent<Rigidbody2D>();
      //_collider = GetComponent<CircleCollider2D>();
   }


	private void OnCollisionEnter2D( Collision2D collision ) 
   {
     if( collision.collider.TryGetComponent(out Platform platform) ) 
     { 
        _stateJumping = new JumpingDown();
        _isGround = true;
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
       _buttonJump.OnClickJump += TryJump;
    }

    private void OnDisable()
    {
       _buttonLeftRun.OnClickMoveLeft -= TransitionMovingLeft;
       _buttonRightRun.OnClickMoveRight -= TransitionMovingRight;
       _buttonLeftRun.OnUpMoveLeft -= StopMove;
       _buttonRightRun.OnUpMoveRight -= StopMove;
       _buttonJump.OnClickJump -= TryJump;
    }
   public void TransitionMovingLeft()  
    { 
      _rigidbody.velocity = Vector2.left * _speed * Time.fixedDeltaTime;
    }
   
   public void TransitionMovingRight() 
   {
      _rigidbody.velocity = -Vector2.left * _speed * Time.fixedDeltaTime;
   }

   public void TryJump() 
   {
      CheckGround( -Vector2.up );
      if( IsGround )
      {
        _stateJumping.TransitionMoveUp( this );
        _isGround = false;
      }
   }


   public void Move( Vector3 gravityVector ) => _typeMove.Move( this, _rigidbody, gravityVector );

   public void SetMoveState( IMoverState state ) => _typeMove = state;
   public void SetJumpState( IJumpingState state ) => _stateJumping = state;



   private void StopMove() 
   {
      _typeMove = new Stoping();
       _rigidbody.velocity = Vector2.zero;
   }

   public void Jump()
   {
     // Debug.Log(_stateJumping);
    //  CheckGround( -Vector2.up );
     //  if( IsGround )
    //   {
         _stateJumping.Jump(  this, _rigidbody );
    //   }
   }

 
   public bool CheckGround( Vector2 rayDirection )
   {
       return _isGround = (Physics2D.Raycast( _legs.position, rayDirection, 0.2f, _groundMask).collider != null);
   }

}
