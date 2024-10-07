using UnityEngine;
using UnityEngine.InputSystem;

public class CameraDrag : MonoBehaviour
{
    private Vector3 _clickOrigin;
    private Vector3 _direction;
    public bool _isDragging;
    Camera mainCamera;
    private Vector3 CurrentMousePos => mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _clickOrigin = CurrentMousePos;
        }
        else if(Input.GetMouseButtonUp(0))
            _isDragging = false;
    }

    private void LateUpdate() 
    {
        if(!_isDragging) return;
        _direction = CurrentMousePos - transform.position;
        transform.position = _clickOrigin - _direction;
    }
}
