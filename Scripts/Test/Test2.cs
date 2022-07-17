using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
	public GameObject cameraObject;
	public GameObject centerObject;
	private Vector3 center;
	private Vector3 VectorToCam;
	



    // Start is called before the first frame update
    void Start()
    {

	VectorToCam = cameraObject.transform.position-centerObject.transform.position;
	center = centerObject.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {

	Quaternion qtest = new Quaternion(0,1,0,0.001f);
	VectorToCam = qtest * VectorToCam;
	VectorToCam.Normalize();
	VectorToCam *= 10;
	Debug.DrawLine(center, center + VectorToCam, Color.red, 0.02f);

        
    }
}
