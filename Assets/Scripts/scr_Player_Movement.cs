using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovimentacaoCarro : MonoBehaviour

{
    // Declarations
    public float speed = 7.5f;                // Player Speed
    public float rotationSensibility = 0.5f;  // Player Rotation Sensibility
    private float horizontalAxis;     // Horizontal Axis of the Scene
    private float verticalAxis;       // Vertical Axis of the Scene
    public Camera playerCamera;              // Player Camera
    public float playerCameraRotSpeed = 2f;  // Camera Rotation

    void Start()
    {
        // Get directional Axis
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis   = Input.GetAxis("Vertical");
    }
    void Update()
    {
        // 'W':
        if(Input.GetKey(KeyCode.W))
        {
            // Translate forward
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        // 'S':
        else if(Input.GetKey(KeyCode.S))
        {
            // Translate backwards
            transform.Translate(Vector3.back * -speed * Time.deltaTime);
        }
        // 'A':
        if(Input.GetKey(KeyCode.A))
        {
            // Rotate counter-clockwise
            transform.Rotate(0, -rotationSensibility, 0);
        }
        // 'D':
        else if(Input.GetKey(KeyCode.D))
        {
            // Rotate clockwise
            transform.Rotate(0, rotationSensibility, 0);
        }

        // [Backspace]
        if(Input.GetKey(KeyCode.Backspace)) {
            // Reset Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }



        if(Input.GetMouseButton(0))
        {
            playerCamera.transform.RotateAround(transform.position, 
                                            playerCamera.transform.up,
                                            -Input.GetAxis("Mouse X")*playerCameraRotSpeed);

            playerCamera.transform.RotateAround(transform.position, 
                                            playerCamera.transform.right,
                                            -Input.GetAxis("Mouse Y")*playerCameraRotSpeed);
        } 
    }
}



