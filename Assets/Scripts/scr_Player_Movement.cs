using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovimentacaoCarro : MonoBehaviour

{
    // Declarations
    public float speed = 7.5f;
    public float rotationSensibility = 0.5f;
    private float horizontalAxis;
    private float verticalAxis;

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
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        // 'S':
        else if(Input.GetKey(KeyCode.S))
        {
            // Translate backwards
            transform.Translate(Vector3.back * speed * Time.deltaTime);
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

        // Ao apertar a barra de apagar
        if(Input.GetKey(KeyCode.Backspace)) {
            // Reset Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}



