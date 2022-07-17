using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGround : MonoBehaviour
{
	  private int _countCollision = 0;
  	private Vector3 _normalVector;
	  private Hero _hero;
    private float _prevAngle;
    public Collision2D ContactCollider { get; private set; }
    public event Action<Vector3> ContactSpaceGround;

    private void Awake()
    {
    	_hero = GetComponent<Hero>();
    }

     private void OnEnable()
  {
    _hero.ContactGround += GetNormVector;

  }

   private void OnDisable()
  {
    _hero.ContactGround -= GetNormVector;
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
