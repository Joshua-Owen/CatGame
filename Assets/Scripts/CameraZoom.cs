using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    //camera zoom
    public Camera mainCamera;
    [SerializeField]
    float minFov = 15f;
    [SerializeField]
    float maxFov = 90f;
    [SerializeField]
    float sensitivity = 10f;

    //camera drag
   CameraDrag cameraDrag;

public SpriteRenderer spriteRenderer;

CameraAspectRatio cameraRatio;

    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        maxFov = spriteRenderer.bounds.size.y / 2f;
        minFov = maxFov/2;
        Camera.main.orthographicSize = maxFov;
        CameraAspectRatio cameraRatio = GetComponent<CameraAspectRatio>();
        spriteRenderer = FindObjectOfType<SpriteRenderer>();
        cameraDrag =  FindObjectOfType<CameraDrag>();
        mainCamera = GetComponent<Camera>();
        print("test");

        
    }


    public void Zoom(InputAction.CallbackContext ctx)
    {
       cameraDrag.OnDrag(ctx);
        //cameraDrag.OnDragz();
        var fov = Camera.main.orthographicSize;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        mainCamera.orthographicSize = fov;
              //  cameraDrag.OnDragz();

       cameraDrag.OnDrag(ctx);

        
    }

    

}

