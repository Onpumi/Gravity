using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineVector : MonoBehaviour
{

	private Vector3 vector_1;
	private Vector3 vector_2;
	private Color _color;


    public void LineSet( Vector3 v1, Vector3 v2, Color color)
     {
	vector_1 = v1;
	vector_2 = v2;
	_color = color;

     }

  
    void Update()
    {
	 //Debug.DrawLine(new Vector3(0,0,0),new Vector3(10,0,0), Color.cyan);	 
        
    }


}
