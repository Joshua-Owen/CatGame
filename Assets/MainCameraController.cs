using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField]
    float minFov = 15f;
    [SerializeField]
    float maxFov = 90f;
    [SerializeField]
    float sensitivity = 10f;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        print("test");


    }


    // Update is called once per frame
    void Update()
    {
        CameraZoom();


    }

    private void CameraZoom()
    {

        var fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        mainCamera.fieldOfView = fov;
    }

    private void CameraMove()
    {
        
    }
}

