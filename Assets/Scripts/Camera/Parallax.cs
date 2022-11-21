using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{


    Vector3 Pos;
    Vector3 newPos;
    Vector3 prevPosCamera;
    float offsetX, offsetY;
    [Range(0, 5f)] public float indexOffset;
    public float dir;
    
    void Start()
    {
	
	prevPosCamera = Camera.main.transform.position;
        
    }

    
    void Update()
    {
	Pos = Camera.main.transform.position;
    offsetX = (Pos.x - prevPosCamera.x) * indexOffset;
	offsetY = (Pos.y - prevPosCamera.y) * indexOffset;
	newPos.x = transform.position.x + offsetX * dir;
	newPos.y = transform.position.y + offsetY * dir;
    newPos.z = transform.position.z;
	prevPosCamera = Pos;
	transform.position = newPos;
    }
}
