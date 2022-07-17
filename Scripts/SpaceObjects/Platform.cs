using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] DrawGL gl;
    private Sprite _sprite;
    private PolygonCollider2D _polygonCollider;
    private Collider2D[] _colliders;
    public bool ContactHero {get; private set; }
    public event Action<Collider2D> ContactPointGround;
    public event Action<Collider2D> ExitPointGround;

        
    private void Awake()
    {
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _sprite = GetComponent<SpriteRenderer>().sprite;
        _colliders = new Collider2D[10];
    }

    private void Start()
    {
  //    _collider = GetComponent<Collider2D>();

     // Debug.Log($"collider {_collider.name}");
    }


    private void OnEnable()
    {
     // _hero.ContactGround += TouchGround;
    }
    private void OnDisable()
    {
      //_hero.ContactGround -= TouchGround;
    }


    private void OnTriggerEnter2D( Collider2D collider )
   {
      if( collider.tag == "Legs")
      {
         ContactHero = true;
         ContactPointGround?.Invoke( collider );
       //  Debug.Log($"Contact {transform.name} width:{collider.name} ");
      }

   }


       private void OnTriggerExit2D( Collider2D collider )
   {
 
      if( collider.tag == "Legs")
      {
        ContactHero = false;
         ExitPointGround?.Invoke( collider );
  //       Debug.Log($"Contact {transform.name} width:{collider.name}");
      }

   }




    private void TouchGround( Collision2D coll )
    {
         //if( _hero.TouchCollider == coll.collider )
         //{
          //  Debug.Log($"коснулись коллайдера нового коллайдера! Его имя {_hero.TouchCollider.name}");
         //}
    }


 private void MakeGravityForceDown( )
   {
     //   var closestPoint = _polygonCollider.ClosestPoint(_hero.transform.localPosition);
        Vector2 closestPoint2;
       // gl.DeleteAllLine();

//       gl.AddLine( closestPoint, closestPoint+(Vector2)transform.up * 5f, Color.red );

  //      var hit = Physics2D.BoxCast( new Vector2(-21,-2), new Vector2(5,5), 0, new Vector2(0,-1), 100 );
        //Physics2D.OverlapCollider(collider)
        
//        ContactFilter2D filter = new ContactFilter2D();
      //  int resultAmount = Physics2D.OverlapCircleNonAlloc( (Vector2)_hero.transform.position,1, _colliders);
        //int resultAmount = _collider.OverlapCollider(filter.NoFilter(), _colliders );
      //   if(_colliders[1] != null)
       // Debug.Log(_colliders[1].name);
      //if( hit )
    //   Debug.Log(hit.transform.name);
   }



    private void FixedUpdate()
    {
        //MakeGravityForceDown();
    }

}
