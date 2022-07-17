using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	[RequireComponent(typeof(Planet))]

 
    public class Planet : MonoBehaviour
 {
    [SerializeField]  private  Hero  _hero;
    [SerializeField]  private  float speedRotate;
	[SerializeField]  private  float _gravityForce;
    private  float _Radius;
	public   float Radius => _Radius;
	private  float tSpeed = 0;
	private  Quaternion Rotate; 
	private  Vector3 AngleVelocity = new Vector3(0,100,0);
	private  Rigidbody2D _rigidbody;
	private  Vector3 _dirGravity;
	public   Vector3  DirGravity => _dirGravity;
	private Collider _collider;
		     

      void Awake()
    {
	   _dirGravity = new Vector3(0,-1,0);
	   _collider = GetComponent<Collider>();
	   _Radius = 144f;
    }

   


   private void MakeGravityForceDown( )
   {
	     if( _rigidbody == null )
	   {
  		  _rigidbody = _hero.GetComponent<Rigidbody2D>();
	   }
	   //_dirGravity = transform.localPosition - _hero.transform.localPosition;
	   //_hero._dirGravity = _dirGravity;
	   if( _rigidbody )
	   {
  	     _rigidbody.AddForce( _dirGravity * _gravityForce);
	   }
   }
   private void FixedUpdate()
   {
	  MakeGravityForceDown( );
   }

}
