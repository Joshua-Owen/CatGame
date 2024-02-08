using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public float targetAspectRatio = 16f / 9f; 
    private void Awake()
    {
        //center of screen
        transform.position *= 0;
        
    }
}

