using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Public Object interraction")]
    public Transform _CameraTransform;

    [Header("Camera Movement")]
    public float _NormalSpeed;
    public float _FastSpeed;

    private float _MovementSpeed;
    public float _MovementTime;

    private Vector3 _newPosition;

    [Header("Camera Angle")]
    public float _RotationAmount;

    private Quaternion _newRotation;

    [Header("Camera Zoom")]
    public Vector3 _ZoomAmount;
    private Vector3 _newZoom;

    public Vector3 _MinZoom;
    public Vector3 _MaxZoom;

    [Header("Camera Mouse Handle")]
    private Vector3 dragStartPos;
    private Vector3 dragCurrentPos;

    private Vector3 rotStartPos;
    private Vector3 rotCurrentPos;

    // Start is called before the first frame update
    void Start()
    {
        _newPosition = transform.position;
        _newRotation = transform.rotation;
        _newZoom = _CameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            _newZoom += Input.mouseScrollDelta.y * _ZoomAmount;
            if(_newZoom.y < _MinZoom.y)
            {
                _newZoom = _MinZoom;
            }
            if(_newZoom.y > _MaxZoom.y)
            {
                _newZoom = _MaxZoom;
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry))
            {
                dragStartPos = ray.GetPoint(entry);
            }
        }
        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPos = ray.GetPoint(entry);

                _newPosition = transform.position + dragStartPos - dragCurrentPos;
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            rotStartPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            rotCurrentPos = Input.mousePosition;

            Vector3 difference = rotStartPos - rotCurrentPos;

            rotStartPos = rotCurrentPos;

            _newRotation *= Quaternion.Euler(Vector3.up * (-difference.x /5f));
        }
    }

    void HandleMovementInput()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _MovementSpeed = _FastSpeed;
        }
        else
        {
            _MovementSpeed = _NormalSpeed;
        }

        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
        {
            _newPosition += (transform.forward * _MovementSpeed);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _newPosition += (transform.forward * -_MovementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _newPosition += (transform.right * _MovementSpeed);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            _newPosition += (transform.right * -_MovementSpeed);
        }

        if(Input.GetKey(KeyCode.A))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * _RotationAmount);
        }
        if(Input.GetKey(KeyCode.E))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * -_RotationAmount);
        }

        if(Input.GetKey(KeyCode.W))
        {
            _newZoom += _ZoomAmount;
        }
        if (Input.GetKey(KeyCode.X))
        {
            _newZoom -= _ZoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * _MovementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * _MovementTime);
        _CameraTransform.localPosition = Vector3.Lerp(_CameraTransform.localPosition, _newZoom, Time.deltaTime * _MovementTime);
    }
}
