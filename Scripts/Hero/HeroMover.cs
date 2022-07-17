using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hero))]
public class HeroMover : MonoBehaviour
{
  [SerializeField] private DrawGL gl;
  [SerializeField] private Hero _hero;
  [SerializeField] private SpaceGravity _space;
  [SerializeField] private Transform _ParentPlatforms;
	[SerializeField] private float _gravityForce;
  [SerializeField] private Transform _legsHero;
	private Vector3  Normal;
	private Vector3 _targetPosition;
  private Vector3 _dirForward;
	private Vector3 _dirMove;
	private Rigidbody2D _rigidbody;
  private float _prevAngle;
  private CircleCollider2D _collider;
  public float RadiusCollider {get; private set; }
  private List<Collider2D> _closestColliders;

    Transform tr;
     

    private void Awake()
    {
	      _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
      	_targetPosition = _rigidbody.position;
        _closestColliders = new List<Collider2D>();
        RadiusCollider =  _collider.radius;
        _dirForward = new Vector3(1,0,0);
    }

    private void OnEnable()
    {
      foreach( Transform platforms in _ParentPlatforms )
      {
           platforms.GetComponent<Platform>().ContactPointGround += AddClosestPointGround;
           platforms.GetComponent<Platform>().ExitPointGround += RemoveClosestPointGround;
      //   platforms.ContactPointGround += AddClosestPointGround;
      //   platforms.ExitPointGround += RemoveClosestPointGround;
      }
    }

    private void OnDisable()
    {
      foreach( Transform platforms in _ParentPlatforms )
      {
           platforms.GetComponent<Platform>().ContactPointGround -= AddClosestPointGround;
           platforms.GetComponent<Platform>().ExitPointGround -= RemoveClosestPointGround;
         //platforms.ContactPointGround -= AddClosestPointGround;
         //platforms.ExitPointGround -= RemoveClosestPointGround;
      }
    }

    private void GetNormalWithRaycast()
    {
      float delta = 0.001f;

      var positionStart1 = transform.position - transform.up * (RadiusCollider+delta) * transform.localScale.y;
      var positionStart2 = transform.position + transform.right * (RadiusCollider+delta) * transform.localScale.x;
      var positionDown = positionStart1 - transform.up;
      var positionForward = positionStart2 + transform.right;
      var hitDown = Physics2D.Linecast( positionStart1, positionDown );
      var hitForward = Physics2D.Linecast( positionStart2, positionForward );

      Debug.DrawLine( positionStart1, positionDown, Color.magenta);
      Debug.DrawLine( positionStart2, positionForward, Color.magenta);
    
      if( hitDown.collider != null )
        Debug.Log($"hitdown {hitDown.collider.name}");
      if( hitForward.collider != null )
        Debug.Log($"hitRight {hitForward.collider.name}");
    }


    private void AddClosestPointGround( Collider2D collider )
    {
      _closestColliders.Add(collider);
    }

    private void RemoveClosestPointGround( Collider2D collider )
    {
        
       foreach( var colliderInList in _closestColliders )
       {
           if( colliderInList.name == collider.name )
          {  
          //  _closestColliders.Remove( colliderInList );
          }
       }
    }

     Vector3 GetNormal(Vector2 directionVector) => new Vector3(-directionVector.y, directionVector.x, 0);	

     public void MoveHero( )
   {
      _dirMove = (Vector3)GetNormal(_space.GravityVector);
      var heroState = _hero.heroState;

        if( heroState != null )
       {
          if( heroState.isMove )
         {
         // Debug.Log($"OK Ground = {_hero.IsGround}  ");
          _dirMove.Normalize();
          _targetPosition = heroState.actionValue * _dirMove * Time.deltaTime * _hero.speed;
           //_hero.TryFlip(_targetPosition.x);  
          //var scaleHero = transform.localScale ;
          //scaleHero.x = heroState.actionValue * transform.localScale.x;
          //transform.localScale = scaleHero;

          if( _hero.IsGround == false ) 
          {
             _targetPosition += (Vector3)Physics2D.gravity *_rigidbody.gravityScale;
          }
          _rigidbody.MovePosition( _hero.transform.position + _targetPosition);
          //_rigidbody.AddRelativeForce(_targetPosition * _hero.speed, ForceMode2D.Force);
          //_rigidbody.AddForce(_targetPosition, ForceMode2D.Force);
         }
       }
       _hero.SetDirection(heroState);
   }

     private void RotateObject( Vector3 vector )
   {
       _dirForward            = new Vector3( 1,0,0 );
    	 _dirForward.x              = (vector.y > _dirForward.y) ? (1) : (-1);
 	     Quaternion newRotation = transform.rotation;
	     float angl_rotate      = Mathf.Abs(Vector3.Angle( vector, _dirForward ));
       var speedRotate = (Mathf.Abs(_prevAngle-angl_rotate) > 30) ? (1f) : (1f);
       newRotation            = Quaternion.Euler( 0, 0, angl_rotate - _dirForward.x * 90 );
       transform.rotation     = Quaternion.Lerp( transform.rotation, newRotation, speedRotate * Time.deltaTime);
       _prevAngle = angl_rotate;
   }

    private void FallDown()
    {
      Physics2D.gravity = _space.GravityVector*_gravityForce;
    }


    private void Update()
    {
      RotateObject( -_space.GravityVector );
    }

    private void FixedUpdate()
    {
         MoveHero();
         FallDown();
         GetNormalWithRaycast();
          if( _closestColliders.Count > 1 )
         Debug.Log(_closestColliders.Count);
    }

    private void LateUpdate()
    {

     // gl.AddLine( transform.position, transform.position + _targetPosition * 5f, Color.red );
      //gl.AddLine( transform.position, transform.position + _space.GravityVector * 5f, Color.green );
     // Debug.DrawLine( transform.position, transform.position + _targetPosition * 5f, Color.red );
      //Debug.DrawLine( transform.position, transform.position + _dirMove * 5f, Color.yellow );
      //Debug.DrawLine( transform.position, transform.position + _space.GravityVector * 5f, Color.green );
    }

}


