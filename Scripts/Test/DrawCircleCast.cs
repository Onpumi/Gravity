using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircleCast : MonoBehaviour
{

    float sizeValue;
    int size = 10;
    LineRenderer lr;
    Vector3 playerPosition;
    float radius;
    float theta;
    float thetaScale;
    float x,y;
    Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        sizeValue = (2.0f * Mathf.PI) / 0.01f;
        size = (int)sizeValue;
        size++;

        lr = GetComponent<LineRenderer>();

        lr.material = new Material(Shader.Find("Standard"));
        lr.material.color = Color.red;
        lr.startWidth = 0.03f;
        lr.endWidth = 0.03f;
        lr.positionCount = size;
    }

    // Update is called once per frame
    void Update()
    {
        DrawCircle();
    }

    void DrawCircle()
    {
//        playerPosition = player.transform.position;
//        playerPosition = transform.localPosition;
//        transform.position = playerPosition;
//        transform.localPosition = playerPosition;
//        radius = player.GetComponent<Player>().shapeRadius; // which is 1f
	
    /*
    radius = 5;
        theta = 0f;
        thetaScale = 0.01f;

        for (int i = 0; i < size; i++)
        {
            theta += (2.0f * Mathf.PI * thetaScale);
            x = radius * Mathf.Cos(theta);
            y = radius * Mathf.Sin(theta);
            
            x += gameObject.transform.position.x;
            y += gameObject.transform.position.y;

            pos = new Vector3(x, y, 0);
            lr.SetPosition(i, pos);
        }
*/
            lr.SetPosition(0, new Vector3(0,0,0));
            lr.SetPosition(1, new Vector3(10,0,0));

    }

















}
