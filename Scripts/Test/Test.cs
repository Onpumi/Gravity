using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{


	public Transform A,B;
	float angle;


	Quaternion rotations = Quaternion.identity;

	Vector3 eulerAngle = Vector3.zero;
	Vector3 axis = Vector3.zero;
	float speed = 0.1f;
	public float tSpeed = 0f;

	Quaternion r1 = Quaternion.identity;
	Quaternion r2 = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



	tSpeed += speed * Time.deltaTime;

//	rotations.eulerAngles = new Vector3(0, 0, tSpeed);
	
//	B.rotation = rotations;
//	A.rotation = rotations;
//	A.eulerAngles = new Vector3(0.0f, 0.0f, tSpeed);
//	rotations.SetLookRotation(A.rotation,B.rotation);

//	A.eulerAngles = new Vector3(0,0,tSpeed);
//	A.rotation.ToAngleAxis(out angle,out axis); // функция записывает параметры в переменные

//	A.rotation = rotations;




//	if( tSpeed > 1 ) tSpeed = 1;

//	transform.rotation = Quaternion.Lerp(A.rotation,B.rotation, tSpeed);

	r1.eulerAngles = transform.eulerAngles;


	Vector3 vec1 = new Vector3(1,0,0);
	Vector3 vec2 = new Vector3(1,1,0);

	angle = Vector3.Angle(vec1, vec2);
	

	r2.eulerAngles = new Vector3(0,0,angle); // тут ставятся углы по осям


//	transform.rotation = Quaternion.Lerp(transform.rotation,r2, tSpeed); //вращение работает
//	transform.position = Vector3.Lerp(transform.position,vec1, tSpeed);  //смещение работает

//	transform.rotation = Quaternion.Lerp(r1,r2, tSpeed);

//	Debug.Log(angle);

        
    }
}
