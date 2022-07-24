using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransitionMoveRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
 public event Action OnClickMoveRight;
   public event Action OnUpMoveRight;
   
 public void OnPointerDown(PointerEventData eventData)
 {
    OnClickMoveRight?.Invoke();
 }

 public void OnPointerUp(PointerEventData eventData)
 {
    OnUpMoveRight?.Invoke();
 }

}
