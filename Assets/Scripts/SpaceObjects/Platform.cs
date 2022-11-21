using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private Sprite _sprite;
    private PolygonCollider2D _polygonCollider;
    private Collider2D[] _colliders;
    public bool ContactHero {get; private set; }
           
    private void Awake()
    {
    }



}
