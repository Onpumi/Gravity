using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactLegs : MonoBehaviour
{


    private void OnCollisionEnter2D( Collision2D coll ) 
     {
  	  
         Debug.Log("contact !");
     }
 
}
