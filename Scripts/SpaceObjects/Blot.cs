using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blot : ObjectSpace
{
   private Vector2 _centerPoint = Vector2.zero;
   public Vector2[] _pointsVertex { get; set; }
   private List<Vector2> simplifiedPoints = new List<Vector2>();

   
    public Blot( PolygonCollider2D polygonCollider, Sprite sprite, Transform item )
    {
        //polygonCollider.pathCount = sprite.GetPhysicsShapeCount();
        Debug.Log(polygonCollider.points.Length);
        _pointsVertex = polygonCollider.points;
        for( int i = 0 ; i < _pointsVertex.Length ; i++ )
        {
            _pointsVertex[i].x *=  item.localScale.x;
            _pointsVertex[i].y *=  item.localScale.y;
            _pointsVertex[i] += (Vector2) item.localPosition;
        }
//        var tolerance = 0.05f;
//        for( int i = 0 ; i < polygonCollider.pathCount ; i++ )
//        {
//            sprite.GetPhysicsShape( i, _pointsVertex );
//            LineUtility.Simplify(_pointsVertex, tolerance, simplifiedPoints );
//            polygonCollider.SetPath(i, simplifiedPoints);
//        }
    }
   

    public override Vector2 GetCenterPoint()
    {
            if( _pointsVertex != null && _pointsVertex.Length > 0)
        {
             for( int i = 0 ; i < _pointsVertex.Length ; i++ )
            {
             _centerPoint.x += _pointsVertex[i].x ;
             _centerPoint.y += _pointsVertex[i].y ;
            }
            _centerPoint.x /= _pointsVertex.Length;
            _centerPoint.y /= _pointsVertex.Length;
            return _centerPoint;
        }
        else 
        {
            return Vector2.zero;
        }

    }

    public override Vector2[] GetPoints() => _pointsVertex;
    


}
