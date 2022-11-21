using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransitionMoveRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
 public event Action OnClickMoveRight;
   public event Action OnUpMoveRight;
   
   int count = 0;
 public void OnPointerDown(PointerEventData eventData)
 {
   Debug.Log(count++);
    OnClickMoveRight?.Invoke();
 }

 public void OnPointerUp(PointerEventData eventData)
 {
    OnUpMoveRight?.Invoke();
 }

}
