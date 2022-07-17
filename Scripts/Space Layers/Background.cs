using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    void Awake()
    {
        
        //transform.gameObject.SetActive(false);
        Destroy(transform.gameObject);
        
    }

}
