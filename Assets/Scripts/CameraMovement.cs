using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public CinemachineCamera cinemachineCamera;
    public CinemachineOrbitalFollow orbitalFollow;
    public float lookSensitivity = 1f, zoomSensitivity = 1f;
    public Vector2 RangeMin, RangeMax; 
    private Vector3 lookInput;
    void Start()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
        orbitalFollow = GetComponent<CinemachineOrbitalFollow>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RangeMax.x = orbitalFollow.HorizontalAxis.Range.y;
        RangeMax.y = orbitalFollow.VerticalAxis.Range.y;
        RangeMin.x = orbitalFollow.HorizontalAxis.Range.x;
        RangeMin.y = orbitalFollow.VerticalAxis.Range.x;
    }    
    void Update()
    {
        lookInput.x = Input.GetAxis("Mouse X");
        lookInput.y = Input.GetAxis("Mouse Y");
        orbitalFollow.HorizontalAxis.Value += lookInput.x * lookSensitivity;
        orbitalFollow.VerticalAxis.Value += lookInput.y * lookSensitivity;
        if(orbitalFollow.VerticalAxis.Value < RangeMin.y)
        {
            orbitalFollow.VerticalAxis.Value = RangeMin.y;
        }
        if(orbitalFollow.VerticalAxis.Value > RangeMax.y)
        {
            orbitalFollow.VerticalAxis.Value = RangeMax.y;
        }
        lookInput.z = Input.GetAxis("Mouse ScrollWheel");
        cinemachineCamera.Lens.FieldOfView -= lookInput.z * zoomSensitivity;
        if(cinemachineCamera.Lens.FieldOfView < 20f)
        {
            cinemachineCamera.Lens.FieldOfView = 20f;
        }
        if(cinemachineCamera.Lens.FieldOfView > 60f)
        {
            cinemachineCamera.Lens.FieldOfView = 60f;
        }
        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            cinemachineCamera.Lens.FieldOfView = 60f;
        }
    }
}    
