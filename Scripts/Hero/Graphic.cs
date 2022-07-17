using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphic : MonoBehaviour
{
  [SerializeField] private Camera _camera;
  [SerializeField] private Transform _target;
  [SerializeField] private Transform _target2;
  

  public Vector2 setPoint( Vector2 point )
  {
    point.x = (int)point.x;
    point.y = Screen.height - (int)point.y;
    return point;
  }

   Rect Coordinats(Vector3 start, Vector3 finish ) => new Rect(start.x,start.y,finish.x,finish.y);
    public void DrawLine( Vector2 pointA, Vector2 pointB, float width, float length )
  {
    pointA = _camera.WorldToScreenPoint((Vector3)pointA);
    pointB = _camera.WorldToScreenPoint((Vector3)pointB);
    pointB = setPoint (pointB);

    Texture2D lineTex = new Texture2D(1,1);
    Matrix4x4 matrixBackup = GUI.matrix;
    GUI.color = Color.red;
    float angle = Mathf.Atan2( pointB.y-pointA.y, pointB.x - pointA.x) * 180f / Mathf.PI;
    GUIUtility.RotateAroundPivot( angle, pointA );
    GUI.DrawTexture( new  Rect (pointA.x, pointA.y, length, width), lineTex);
    GUI.matrix = matrixBackup;
  }

  void OnGUI()
  {
    Vector3 endPosition = new Vector3( 1f, 1f, 0);
    //DrawLine( _target.position, _target2.position, 3.0f, 100f);  

  }
}
