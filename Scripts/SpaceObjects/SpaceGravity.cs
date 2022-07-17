using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGravity : MonoBehaviour
{
   [SerializeField]  private float _maxGravityDistance;
   [SerializeField]  private Hero _hero;
   [SerializeField]  private float _gravityForce;
   [SerializeField]  private HeroGround _heroground;
   private float _minDistanceContact = 0.3f;
   private float _minGravityDistance;
   private List<Transform> _platforms;
   private Platform _nearPlatform;
   private Platform[] _platformObjects;
   private Collider2D[] _collidersPlatform;
   public List<Platform> SpacePlatforms { get; private set; }
   private List<Transform> _characters;
   public Vector3 GravityVector {get; private set;}

   


   private void Awake()
   {
      _platforms = new List<Transform>();
      SpacePlatforms = new List<Platform>();
      _characters = new List<Transform>();

      foreach( Transform child in transform )
      {
        _platforms.Add(child);
        SpacePlatforms.Add(child.gameObject.GetComponent<Platform>());
      }
       var countObjects = transform.childCount;
      _platformObjects = new Platform[countObjects];
      _collidersPlatform = new Collider2D[countObjects];


      for( int i = 0 ; i < countObjects ; i++ )
      {
        _collidersPlatform[i] = SpacePlatforms[i].GetComponent<Collider2D>();
      }
 
      SetGravityVector( );
   }

 

   private void OnEnable()
   {
      _heroground.ContactSpaceGround += SetGravityVector;
   }

    private void OnDisable()
   {
      _heroground.ContactSpaceGround -= SetGravityVector;
   }

   private float GetDistanceBetweenPoints( Vector3 point1, Vector3 point2 )
   {
     return Mathf.Pow((Mathf.Pow((point1.x-point2.x),2) + Mathf.Pow((point1.y-point2.y),2)),0.5f);
   }

   private void SetGravityVector( Vector3 vector )
   {
      GravityVector = vector;
   }


   private Vector3 GetGravityVector()
   {
       var vectorGravity = Vector3.zero;
       float countVector = 0;
       for( int i = 0 ; i < _platformObjects.Length ; i++ )
       { 
          var closestPoint = (Vector3)  _collidersPlatform[i].ClosestPoint(_hero.transform.localPosition);
          var positionHero = _hero.transform.localPosition;
          if( Vector3.Distance(closestPoint, positionHero) <= _minDistanceContact )
         {
           vectorGravity += (closestPoint - positionHero);
           countVector++;
         }
       }
       vectorGravity /= countVector;
       return vectorGravity;
   }

   private void SetGravityVector( )
   {
      _minGravityDistance = _maxGravityDistance;
      _nearPlatform = SpacePlatforms[0];
      for( int i = 0 ; i < _platforms.Count ; i++ )
      {
             var distance = GetDistanceBetweenPoints( _platforms[i].position, _hero.transform.position );
            if( distance < _minGravityDistance)
            {
               _minGravityDistance = distance;
              _nearPlatform = SpacePlatforms[i];
            }
      }
      var collider = _nearPlatform.GetComponent<Collider2D>();
      if( Vector3.Distance((Vector3) collider.ClosestPoint(_hero.transform.localPosition), _hero.transform.localPosition ) > _minDistanceContact )
      {
       GravityVector = (Vector3) collider.ClosestPoint(_hero.transform.localPosition) - _hero.transform.localPosition;
      // GravityVector = new Vector3(0,-1,0);
      }
      else 
      {
         GravityVector = GetGravityVector();
      }
       GravityVector.Normalize();
   }

   private void FixedUpdate()
   {     
      if( _hero.IsGround == false )
        {
           SetGravityVector( );
        }
   }
}
