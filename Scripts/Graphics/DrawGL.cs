using UnityEngine;
using System.Collections.Generic;
public class DrawGL : MonoBehaviour
{
   [SerializeField] Transform _target;
   public Material mat;
   private Camera cam;
   private Vector3 _startPoint;
   private Vector3 _endPoint;
   private bool _startDraw = false;
   private List<Vector3[]> pointsLine =  new List<Vector3[]>();
   private Color _color;

   private void Awake()
   {
      cam = Camera.main;
      _startPoint = Vector3.zero;
      _endPoint = Vector3.zero;
      _color = Color.white;
   }

      void OnPostRender()
   {
      Vector3 _vector = new Vector3(0,1,0);

     if( _startDraw ) 
     {
        foreach( var points in pointsLine)
        {
          DrawLine( points[0], points[1] );
        }
     }
     
   }


      Rect Coordinats(Vector3 start, Vector3 finish ) => new Rect(start.x,start.y,finish.x,finish.y);

      public void DrawLine( Vector3 _beginPointLine, Vector3 _endPointLine )
   {
      _beginPointLine = cam.WorldToScreenPoint(_beginPointLine);
      _endPointLine = cam.WorldToScreenPoint(_endPointLine);
      Rect rect = Coordinats(_beginPointLine, _endPointLine);
      if( mat == null )
      {
        Shader shader = Shader.Find("Hidden/Internal-Colored");
        mat = new Material(shader);
        mat.hideFlags = HideFlags.HideAndDontSave;
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        mat.SetInt("_ZWrite", 0);
      }
      GL.PushMatrix();
      mat.SetPass(0);
      GL.LoadOrtho();
      GL.Begin (GL.LINES);
      GL.Color(_color);
      GL.Vertex3( rect.x/Screen.width, rect.y/Screen.height, 0);
      GL.Vertex3( rect.width/Screen.width, rect.height/Screen.height, 0);
      
      GL.End();
      GL.PopMatrix();
   }

     public void AddLine( Vector3 startPoint, Vector3 endPoint, Color color )
     {
        _startPoint = startPoint;
        _endPoint = endPoint;
        _startDraw = true;
         Vector3[] points = new Vector3[2];
          points[0] = startPoint;
          points[1] = endPoint;
          _color = color;
          pointsLine.Add( points );
     }

     public void DeleteAllLine()
     {
       if( pointsLine.Count > 0 )
       {
         for( int i = 0; i < pointsLine.Count ; i++ )
         pointsLine.RemoveAt(i);
       }
     }

   private void Update()
   {
      DeleteAllLine();
   }

}
