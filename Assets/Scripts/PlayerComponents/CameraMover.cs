using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CameraMover : MonoBehaviour
{

    [SerializeField, Range(20, 50)] private float _moveSpeed;
    [SerializeField, Range(20, 50)] private float _rotateSpeed;
    [SerializeField, Range(5, 50)] private float _zoomSpeed;

    [SerializeField] private Camera _camera;

    protected PlayerInput _input;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {    
        _input.Enable();      
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        OnCameraMove();
        OnCameraRotate();
        OnCameraZoom();
    }

    private void OnCameraMove()
    {
        var _inputMoveDirection = _input.Moving.Move.ReadValue<Vector3>();
        var moveDirection = new Vector3(_inputMoveDirection.x, 0, _inputMoveDirection.z) * _moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection);
    }

    private void OnCameraRotate()
    {
        var _inputRotateDirection = _input.Moving.Rotate.ReadValue<float>();
        float AxisY = _inputRotateDirection * _rotateSpeed * Time.deltaTime;
        transform.Rotate(0, AxisY, 0);
    }

    private void OnCameraZoom()
    {
        var _inputZoom = _input.Moving.Zoom.ReadValue<float>();
        float zoom = _inputZoom * _zoomSpeed * Time.deltaTime;
        _camera.fieldOfView += zoom; 
    }
}
