using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player_Movement : MonoBehaviour

{
    // Declarations
    public float speed = 7.5f;                // Player Speed
    public float rotationSensibility = 0.5f;  // Player Rotation Sensibility
    private float horizontalAxis;     // Horizontal Axis of the Scene
    private float verticalAxis;       // Vertical Axis of the Scene

    void Start()
    {
        // Get directional Axis
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis   = Input.GetAxis("Vertical");
    }


    void Update()
    {
        // 'W':
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Translate forward
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        // 'S':
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Translate backwards
            transform.Translate(Vector3.back * -speed * Time.deltaTime);
        }
        // 'A':
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate counter-clockwise
            transform.Rotate(0, -rotationSensibility * Time.deltaTime, 0);
        }
        // 'D':
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate clockwise
            transform.Rotate(0, rotationSensibility * Time.deltaTime, 0);
        }

        // [Backspace]
        if(Input.GetKey(KeyCode.Backspace)) {
            // Reset Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}



