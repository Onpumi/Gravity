using System;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class TransitionJump : MonoBehaviour, IPointerDownHandler
{

   public event Action OnClickJump;

    public void OnPointerDown(PointerEventData eventData)
 {
    OnClickJump?.Invoke();
 }


}
