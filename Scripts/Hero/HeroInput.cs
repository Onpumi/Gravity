using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class HeroInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
  private Hero _hero;
  public event UnityAction<HeroInput> buttonDown;
  public event UnityAction<HeroInput> buttonUp;
  public event UnityAction buttonJump;

   private void Awake()
  {
  	_hero = GetComponent<Hero>();
  }
   private void Update()
  {
  //  if ( Input.GetAxis("Horizontal") > 0 ) _mover.StartMove(StateType.Right);
	//  else if ( Input.GetAxis("Horizontal") < 0 ) _mover.StartMove(StateType.Left);
    if(Input.GetKeyDown(KeyCode.M))
		{
      buttonJump?.Invoke();
		}

    if( Input.GetKeyDown(KeyCode.B) )
    {
      Debug.Log(_hero.heroState);
    }

    if( Input.GetAxis("Cancel") > 0 )
 	  {
	    Application.Quit();
	  }

  }

  public void OnPointerDown(PointerEventData e)
  {
    buttonDown?.Invoke(this);
  }

   public void OnPointerUp(PointerEventData e)
  {
    buttonUp?.Invoke(this);
  }

}
