
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class TransitionMoveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   public event Action OnClickMoveLeft;
   public event Action OnUpMoveLeft;
   
 public void OnPointerDown(PointerEventData eventData)
 {
    OnClickMoveLeft?.Invoke();
 }

 public void OnPointerUp(PointerEventData eventData)
 {
    OnUpMoveLeft?.Invoke();
 }
}
