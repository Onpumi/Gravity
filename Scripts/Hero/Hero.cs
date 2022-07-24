using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;



[RequireComponent(typeof(Hero))]

public class Hero : MonoBehaviour
{
   [SerializeField] private Transform _buttonsControl;
   [SerializeField] private TransitionMoveLeft _buttonLeftRun;
   [SerializeField] private TransitionMoveRight _buttonRightRun;
   [SerializeField] private Button _buttonJump;
	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;
   [SerializeField] private Transform _legs;
   [SerializeField] private LayerMask _maskaPlace;
   IMoverState _typeMove = new Stoping();
   public Sprite Sprite { get; private set; }
	private bool _faceDirectionRight;
	private bool _isGround = false;
   public bool IsGround => _isGround;
   public event Action<Collision2D> ContactGround;
   public int FaceDirection =>  (_faceDirectionRight) ? (1) : (-1);
   public float Speed  { get => _speed; }
   public float JumpForce { get => _jumpForce; }
   private Rigidbody2D _rigidbody;

   private void Awake()
   {
      Sprite = GetComponent<SpriteRenderer>().sprite;
      _rigidbody = GetComponent<Rigidbody2D>();
   }

	private void OnCollisionEnter2D( Collision2D coll ) 
   {
     if( coll.collider.tag == "Green" ) 
     { 
 	    _isGround = true;
     }
   }

       private void OnCollisionStay2D( Collision2D coll )
     {
	     if( coll.collider.tag == "Green") 
        {
         ContactGround.Invoke(coll);
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
    }

    private void OnDisable()
    {
       _buttonLeftRun.OnClickMoveLeft -= TransitionMovingLeft;
       _buttonRightRun.OnClickMoveRight -= TransitionMovingRight;
       _buttonLeftRun.OnUpMoveLeft -= StopMove;
       _buttonRightRun.OnUpMoveRight -= StopMove;
    }
   public void TransitionMovingLeft() => _typeMove.TransitionMovingLeft( this );
   
   public void TransitionMovingRight() => _typeMove.TransitionMovingRight( this );

   public void Stop() => _typeMove.Stop( this );

   public void Move( Vector3 gravityVector ) => _typeMove.Move( this, _rigidbody, gravityVector );

   public void SetMoveState( IMoverState state ) => _typeMove = state;

   private void StopMove() => Stop();

   private void CheckGround( Transform target )
   {
      RaycastHit2D hitDown = Physics2D.Raycast( target.position, -transform.up, 0.1f, _maskaPlace );

      if( hitDown.collider && hitDown.collider.tag == "Green" )
      {
         _isGround = true;
      }
   }
   private void Update()
   {
      CheckGround(_legs);
   }
}
