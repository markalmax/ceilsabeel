using NUnit.Framework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float FlySpeed = 5;
    public float YawAmount = 120;

    public GameObject pauseMenu;
    public bool isPaused = true;
    private float Yaw;
    private Vector2 input;
    void Start()
    {
    }
    void Update()
    {
        if(isPaused && Input.anyKeyDown)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            isPaused = true;
        }
        if(isPaused) return;
        transform.position += transform.forward * FlySpeed * Time.deltaTime;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        Yaw += input.x * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(input.y)) * Mathf.Sign(input.y);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(input.x)) * -Mathf.Sign(input.x);
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);
        
    }
}
