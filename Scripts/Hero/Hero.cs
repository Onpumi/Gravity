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

   [SerializeField] private Transform _buttonsHero;
	[SerializeField] public  float speed;
	[SerializeField] private float jspeed;
   public Sprite Sprite { get; private set; }
	public IHeroState  heroState;
	private HeroInput[] _heroInputs;
	private bool _facingRight = true;
//	private int _facingDir = 1;
//	public int facingDir => _facingDir;
	private bool _isGround = false;
	public Vector3 DirGravity { get; private set; }
   private CircleCollider2D _collider;
   public CircleCollider2D collider => _collider;
   public List<Collider2D> TouchGroundColliders {get; private set; }
   public bool IsGround => _isGround;
   public event Action<Collision2D> ContactGround;
   public event Action<Hero> UpdateDirectionFall;
   public ActionsHero actionsHero;


   private void Awake()
   {
      _collider = GetComponent<CircleCollider2D>();
      Sprite = GetComponent<SpriteRenderer>().sprite;
      TouchGroundColliders = new List<Collider2D>();
      actionsHero = ScriptableObject.CreateInstance<ActionsHero>();
    //  Vector3 v = new Vector3(1,1,1);
   //  Sprite.bounds.Encapsulate(v);
    //  Debug.Log($"Sprite - {Sprite.bounds.min}");
   }



	private void OnCollisionEnter2D( Collision2D coll ) 
     {
  	     if( coll.collider.tag == "Green" ) 
	     { 
	  	    _isGround = true;
            TouchGroundColliders.Add(coll.collider);
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
          TouchGroundColliders.Remove(coll.collider);
          //Debug.Log(TouchGroundColliders.Count);
        }
     }

     public void SetDirection( IHeroState State )
   {
	    Vector3 localScale = transform.localScale;

       if( State.actionValue == actionsHero.actionsValue["MoveRight"])
       {
         _facingRight = true;
         
       }
       else if( State.actionValue == actionsHero.actionsValue["MoveLeft"])
       {
         _facingRight = false;
         
       }

  	    localScale.x = (_facingRight) ? (localScale.x) : (-localScale.x);

         if( _facingRight == true )
         {
            localScale.x *= (localScale.x < 0) ? (-1) : (1);
         }
         else
         {
            localScale.x *= (localScale.x < 0) ? (1) : (-1);
         }
	    transform.localScale = localScale;
   }

  private void OnEnable()
    {
       var countButtons = _buttonsHero.childCount;
       _heroInputs = new HeroInput[countButtons];

       for(int i = 0 ; i < countButtons; i++)
       {
         _heroInputs[i] = _buttonsHero.GetChild(i).GetComponent<HeroInput>();
         _heroInputs[i].buttonDown += DoAction;
		   _heroInputs[i].buttonUp += StopMove;
		   _heroInputs[i].buttonJump += ReadyJump;
       }
    //   _spaceGravity.GravityForce += SetGravityVector;
    }

    private void OnDisable()
    {
       for( int i = 0 ; i < _heroInputs.Length ; i++ )
       {
          _heroInputs[i].buttonDown -= DoAction;
		    _heroInputs[i].buttonUp -= StopMove;
		    _heroInputs[i].buttonJump -= ReadyJump;
       }
     //  _spaceGravity.GravityForce -= SetGravityVector;
    }

   private void DoAction( HeroInput input )
   {
	 if( input.name == "MoveLeft" )
	 {
		heroState = new MovingLeftState();
	 }
	 else if( input.name == "MoveRight" )
	 {
		heroState = new MovingRightState();
	 }
	 //_stateMove = _actionsHero.actionsValue[input.name];
   }

   private void StopMove( HeroInput input )
   {
		heroState = new MovingStopState();
	 //_stateMove = _actionsHero.actionsValue["None"];
   }
   private void ReadyJump()
   {
	//_stateMove = _actionsHero.actionsValue["Jump"];
   }

   private void FixedUpdate()
   {   

     // UpdateDirectionFall?.Invoke(this);
    
   }


   private void Update()
   {

	   
   }
}
