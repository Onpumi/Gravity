using UnityEngine;

public class Jumping
{
    public float PositionJump {get; private set; }
    protected float _currentPosition;
    private Vector3 _targetPosition;
    private float _height = 1f;
    private float _startHeight;
    private Vector2 _startPosition;
    protected float _heightJump = 25f;
    protected float _deltaJump = 0f;
    protected float _startPositionY;
    

     protected void SetPositionRigidbody( Hero hero, Rigidbody2D rigidbody )
    {
       
        if( _deltaJump == 0f)
        {
            _startPositionY = rigidbody.position.y;
            rigidbody.velocity += Vector2.up * _heightJump;
        }

    //    rigidbody.gravityScale = 0f;
        _deltaJump += 20f * Time.fixedDeltaTime;
       //  rigidbody.position = new Vector2(rigidbody.position.x, _startPositionY + _deltaJump);

       //rigidbody.velocity += Vector2.up * 10;
      
    }
    


}
