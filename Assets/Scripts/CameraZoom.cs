using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    //camera zoom
    Camera mainCamera;
    [SerializeField]
    float minFov = 15f;
    [SerializeField]
    float maxFov = 90f;
    [SerializeField]
    float sensitivity = 10f;

    //camera drag
   CameraDrag cameraDrag;





    // Start is called before the first frame update
    void Start()
    {
        cameraDrag =  FindObjectOfType<CameraDrag>();
        mainCamera = GetComponent<Camera>();
        print("test");


    }


    public void Zoom(InputAction.CallbackContext ctx)
    {
        cameraDrag.OnDrag(ctx);
        var fov = Camera.main.orthographicSize;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        mainCamera.orthographicSize = fov;
        cameraDrag.OnDrag(ctx);

        
    }

    

}

