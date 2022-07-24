using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroJumper : MonoBehaviour
{
  [SerializeField] private HeroInput _buttonJump;
   private Vector3 _pointEndPosition;
   private float lengthJump;
   private bool _isStartJump = false;

    private void OnEnable()
    {
        _buttonJump.Jumper += Jump; 
    }

   
    private void StartJump()
    {
        _isStartJump = true;
        _pointEndPosition = transform.position + transform.up * 1f;

    }
    private void Jump()
    {
        StartJump();

        Debug.Log("Jumper");

       // Vector3 finishPosition = transform.position + transform.up * 1f;
       // transform.position = Vector3.Lerp( transform.position, finishPosition, 3f * Time.deltaTime);
    }
    void Update()
    {
        
    }
}
