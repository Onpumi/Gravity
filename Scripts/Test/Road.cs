using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

      //public List<Vector2> fingerPos;

	EdgeCollider2D ecl;
    // Start is called before the first frame update
    void Start()
    {
       ecl = GetComponent<EdgeCollider2D>(); 

	//Debug.Log(ecl.pointCount);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
