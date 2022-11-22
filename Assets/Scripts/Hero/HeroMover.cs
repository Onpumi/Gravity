using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMover : MonoBehaviour
{
  [SerializeField] private Hero _hero;
  [SerializeField] private SpaceGravity _space;
  [SerializeField] private Transform _ParentPlatforms;
	[SerializeField] public float GravityForce { get; private set;}
  [SerializeField] private HeroGround _heroground;
  [SerializeField] private LayerMask _maskaRaycast;
  private IMoverState _stateMove = new Stoping();
	private Vector3  Normal;
	private Vector3 _targetPosition;
  private Vector3 _dirForward;
	private Vector3 _dirMove;
	private Rigidbody2D _rigidbody;
  private float _prevAngle;
  private MoveTransitions _moveTransitions;
  private CircleCollider2D _collider;
  public float RadiusCollider {get; private set; }
  

    Transform tr;
     

    private void Awake()
    {
	      _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
      	_targetPosition = _rigidbody.position;
//        RadiusCollider =  _collider.radius;
        _dirForward = new Vector3(1,0,0);
        _moveTransitions = new MoveTransitions();
    }

   


     Vector3 GetNormal(Vector2 directionVector) => new Vector3(-directionVector.y, directionVector.x, 0);	

     public Vector3 GetNormalGravity() => new Vector3(-_space.GravityVector.y, _space.GravityVector.x, 0);	


     private void RotateObject( Vector3 vector )
   {
       _dirForward            = new Vector3( 1,0,0 );
    	 _dirForward.x              = (vector.y > _dirForward.y) ? (1) : (-1);
 	     Quaternion newRotation = transform.rotation;
	     float angl_rotate      = Mathf.Abs(Vector3.Angle( vector, _dirForward ));
       var speedRotate = (Mathf.Abs(_prevAngle-angl_rotate) > 30) ? (35f) : (10f);
       newRotation            = Quaternion.Euler( 0, 0, angl_rotate - _dirForward.x * 90 );
       transform.rotation     = Quaternion.Lerp( transform.rotation, newRotation, speedRotate * Time.deltaTime);
       _prevAngle = angl_rotate;
   }

    private void SetPhysicGravity() => Physics2D.gravity = _space.GravityVector*_space.GravityForce;
    

/*
    private void Update()
    { 
       // RotateObject( -_space.GravityVector );
     //  if(_hero.IsCanJump)
       //_hero.Jump();
    }
*/

    private void FixedUpdate()
    {

           _hero.Jump();
           //_hero.Move(_space.GravityVector);
           
         //  SetPhysicGravity();
        
         if( Input.GetAxis("Cancel") > 0 )
 	    {
	       Application.Quit();
	    }

    }
/*
    private void LateUpdate()
    {

      //gl.AddLine( transform.position, transform.position + _space.GravityVector * 5f, Color.green );
     // Debug.Log(_targetPosition);
     // Debug.DrawLine( transform.position, transform.position + _targetPosition * 5f, Color.red );
    //  Debug.DrawLine( transform.position, transform.position + _dirMove * 5f, Color.yellow );
    //  Debug.DrawLine( transform.position, transform.position + _heroground.GetNormalWithRaycast() * 5f, Color.blue );
     // Debug.DrawLine( transform.position, transform.position + _space.GravityVector * 5f, Color.green );
    }

    */

}


