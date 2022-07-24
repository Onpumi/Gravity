using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] [Range(0, 10f)] private float _dumping;
    [SerializeField] [Range(0, 5f)] private float _offsetX;
    [SerializeField] [Range(0, 5f)] private float _offsetY;

    private void Awake()
    {
	    Screen.orientation = ScreenOrientation.LandscapeLeft;
        CameraSetPosition(_player.position);
	    //Camera.main.orthographicSize = 50f;
       Camera.main.orthographicSize = 8f;
       Vector3 position = _player.position;
       position.z = -10;
       transform.position = position;
      //  StartCoroutine(CameraZoom(8f, 0.5f));
    }

   IEnumerator CameraZoom(float target, float zoomSpeed)
   {

	float from = Camera.main.orthographicSize;
	float time = 0;

	while( time < 1f) {

      time += zoomSpeed * Time.deltaTime;
	  Camera.main.orthographicSize = Mathf.Lerp( from, target, time);	
	  yield return new WaitForSeconds(Time.deltaTime);

	}
   }

   void CameraSetPosition(Vector3 target)
   {
	Vector3 new_position;
	Quaternion new_rotate;
	new_position = transform.position;
	new_position.x = _player.position.x;
	new_position.y = _player.position.y;
	new_rotate = _player.rotation;
	transform.position = Vector3.Lerp(transform.position,new_position, _dumping * Time.deltaTime);
	transform.rotation = Quaternion.Lerp(transform.rotation,new_rotate, _dumping * Time.deltaTime);
   }

    void Update()
    {
       CameraSetPosition(_player.position);
    }
}
