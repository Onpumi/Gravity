using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGround : MonoBehaviour
{
    [SerializeField] private LayerMask _maskaRaycast;
	  private int _countCollision = 0;
  	private Vector3 _normalVector;
	  private Hero _hero;
    private float _prevAngle;
    public Collision2D ContactCollider { get; private set; }
    public event Action<Vector3> ContactSpaceGround;
    public float RadiusCollider { get; private set; }
    private CircleCollider2D _collider;

    private void Awake()
    {
    	_hero = GetComponent<Hero>();
      _collider = GetComponent<CircleCollider2D>();
    }

     private void OnEnable()
  {
    _hero.ContactGround += GetNormVector;
  }

   private void OnDisable()
  {
    _hero.ContactGround -= GetNormVector;
  }


    public Vector3 GetNormalWithRaycast()
    {
      float delta = 1f;
      float hitLength = RadiusCollider * 50f;

      var positionStartHitDown = transform.position - transform.up * (RadiusCollider+delta) * transform.localScale.y - transform.up ;
      var positionStartHitRight = transform.position + transform.right * (RadiusCollider+delta) * transform.localScale.x + transform.right;
      var positionStartHitLeft = transform.position - transform.right * (RadiusCollider+delta) * transform.localScale.x - transform.right;
      var positionEndHitDown = positionStartHitDown - transform.up * hitLength;
      var positionEndHitRight = positionStartHitRight + transform.right * hitLength;
      var positionEndHitLeft = positionStartHitLeft - transform.right * hitLength;

      RaycastHit2D hitDown = Physics2D.Raycast( transform.position, -transform.up, 10, _maskaRaycast );

      RaycastHit2D hitRight = Physics2D.Raycast( transform.position, transform.right, 1, _maskaRaycast );
      RaycastHit2D hitLeft = Physics2D.Raycast( transform.position, -transform.right, 1, _maskaRaycast );
      var averageNormal = (Vector3)hitDown.normal + (Vector3)hitLeft.normal + (Vector3)hitRight.normal;

      averageNormal /= 3f;

      Debug.DrawLine( positionStartHitDown, positionEndHitDown, Color.magenta);
      Debug.DrawLine( positionStartHitRight, positionEndHitRight, Color.magenta);
      Debug.DrawLine( positionStartHitLeft, positionEndHitLeft, Color.magenta);
      averageNormal.Normalize();
      
//      Debug.Log(hitDown.collider.name);

      //Debug.DrawLine( transform.position, transform.position + (Vector3), Color.white);
      //return averageNormal;
     
      return averageNormal;
    }




   private void GetNormVector(Collision2D coll) 
  {
   	_countCollision = 0;
    _normalVector = Vector3.zero;
    ContactCollider = coll;
    var vectorFall = coll.collider.ClosestPoint(transform.position)-(Vector2)transform.position;
    ContactSpaceGround?.Invoke(vectorFall);

	    foreach (ContactPoint2D cont in coll.contacts) 
      {
		   _countCollision++;
	 	   _normalVector += new Vector3(cont.normal.x,cont.normal.y,0);
	    }
         _normalVector /= _countCollision;
	      _normalVector.Normalize();
    }

   private Vector3 Project(Vector3 forward)
  {
   	 forward.Normalize();
	   return forward - Vector3.Dot(forward, _normalVector) * _normalVector;
  }

      Vector3 GetNormal(Vector2 V) 
  {
     return new Vector3(-V.y, V.x, 0);	
  }

}
