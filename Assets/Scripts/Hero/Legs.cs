using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
 
    private void OnTriggerEnter2D( Collider2D collider )
   {
       //if( collider.TryGetComponent(out Platform platform) )
       {
         Debug.Log("земля");
       }
   }

}
