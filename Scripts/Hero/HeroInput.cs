using System;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;




public class HeroInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
  
  private Hero _hero;
  

  public event Action<HeroInput> ButtonDown;
  public event Action Jumper;
  public event Action ButtonUp;
  private GraphicRaycaster m_Raycaster;
  private PointerEventData m_PointerEventData;
  private EventSystem m_EventSystem;


   private void Awake()
  {
  	_hero = GetComponent<Hero>();
    m_Raycaster = GetComponent<GraphicRaycaster>();
    m_EventSystem = GetComponent<EventSystem>();
    
  }

  

   private void Update()
  {

    if(Input.GetKeyDown(KeyCode.Mouse0))
    {
    //   m_PointerEventData = new PointerEventData(m_EventSystem);
  //     m_PointerEventData.position = Input.mousePosition;
//       List<RaycastResult> results = new List<RaycastResult>();
//       m_Raycaster.Raycast(m_PointerEventData, results);
   //   foreach(RaycastResult result in results)
    //  {
       // Debug.Log($" Hit {result.gameObject.name}");
    //  }
    }

    if(Input.GetKeyDown(KeyCode.M))
		{
      
		}

    if( Input.GetKeyDown(KeyCode.B) )
    {

    }

    if( Input.GetAxis("Cancel") > 0 )
 	  {
	    Application.Quit();
	  }

  }

  public void OnPointerDown(PointerEventData eventData)
  {
    //Debug.Log(eventData.pointerCurrentRaycast.gameObject);
    //  SelectedButton = eventData.pointerCurrentRaycast.gameObject.transform;

  }

      public void OnDrag(PointerEventData eventData)
    {
        //Position = eventData.position;
        //Delta = eventData.delta;
        //Debug.Log(eventData.delta);
        //transform.position = eventData.pointerCurrentRaycast.screenPosition;
    }


   public void OnPointerUp(PointerEventData eventData)
  {
    ButtonUp?.Invoke();
  }

  private void OnButtonClicked()
  {
    //  ButtonDown?.Invoke();
  }

}
