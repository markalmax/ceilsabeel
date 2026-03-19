using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public CinemachineCamera cinemachineCamera;
    public CinemachineOrbitalFollow orbitalFollow;
    public float lookSensitivity = 1f, zoomSensitivity = 1f;
    private Vector3 lookInput;
    void Start()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
        orbitalFollow = GetComponent<CinemachineOrbitalFollow>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }    
    void Update()
    {
        lookInput.x = Input.GetAxis("Mouse X");
        lookInput.y = Input.GetAxis("Mouse Y");
        orbitalFollow.HorizontalAxis.Value += lookInput.x * lookSensitivity;
        orbitalFollow.VerticalAxis.Value += lookInput.y * lookSensitivity;
        if(orbitalFollow.VerticalAxis.Value < -90f)
        {
            orbitalFollow.VerticalAxis.Value = -90f;
        }
        if(orbitalFollow.VerticalAxis.Value > 90f)
        {
            orbitalFollow.VerticalAxis.Value = 90f;
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
