using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraDrag : MonoBehaviour
{
    #region Variables

    private Vector3 _origin;
    private Vector3 _difference;

    private Camera _mainCamera;

    private bool _isDragging;
    //boundaries
    private Bounds _cameraBounds;
    private Vector3 _targetPosition;


    #endregion

    private void Awake() => _mainCamera = Camera.main;

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started) _origin = GetMousePosition();
        _isDragging = ctx.started || ctx.performed;
    }

    private void Update()
    {
        SetBoundaries();
        Drag();
    }

    private void SetBoundaries()
    {

        var height = _mainCamera.orthographicSize;
        var width = height * _mainCamera.aspect;

        var minX = Globals.WorldBounds.min.x + width;
        var maxX = Globals.WorldBounds.extents.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.extents.y - height;

        _cameraBounds = new Bounds();
        _cameraBounds.SetMinMax(new Vector3(minX, minY, z: 0.0f), new Vector3(maxX, maxY, z: 0.0f));
    }



    private void Drag()
    {
        if (!_isDragging) return;

        _difference = GetMousePosition() - transform.position;

        _targetPosition = _origin - _difference;
        _targetPosition = GetCameraBounds();

        transform.position = _targetPosition;
    }

    private Vector3 GetCameraBounds()
    {
        return new Vector3(
                            Mathf.Clamp(_targetPosition.x, _cameraBounds.min.x, _cameraBounds.max.x),
                            Mathf.Clamp(_targetPosition.y, _cameraBounds.min.y, _cameraBounds.max.y),
                            transform.position.z


        );
    }
    private Vector3 GetMousePosition()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = 10;

        return _mainCamera.ScreenToWorldPoint(MousePos);

    }
}