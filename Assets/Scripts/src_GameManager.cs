using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class src_GameManager : MonoBehaviour
{
    public GameObject PlayerCamera;
    public GameObject Timer;
    public int time;
    public src_DeliveryArea scriptDeliveryArea;
    private int startingTime;

    // Start is called before the first frame update
    void Start()
    {
        scriptDeliveryArea = FindObjectOfType<src_DeliveryArea>();
    }

    

    public void Play(int duration = 60)
    {
        scriptDeliveryArea.ChangeCamera(1);
        startingTime = duration;
        time = duration;
        TimerTick();
        InvokeRepeating("TimerTick", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckResetKey();
    }

    private void CheckResetKey()
    {
        if (Input.GetKeyDown(KeyCode.R) && !PlayerCamera.GetComponent<Camera>().enabled) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void TimerTick()
    {
        time--;

        int seconds = time % 60;
        int minutes = time / 60;

        Timer.GetComponent<TextMesh>().text = minutes.ToString().PadLeft(2, '0') + ':' + seconds.ToString().PadLeft(2, '0');

        if(time > 2*startingTime/3) { // > 66%
            Timer.GetComponent<TextMesh>().color = Color.green;
        } else if (time <= 2*startingTime/3 && time > startingTime/3) { // 33% > time >= 66%
            Timer.GetComponent<TextMesh>().color = Color.yellow;
        } else if (time > 0 && time <= startingTime/3 ){ // <= 33%
            Timer.GetComponent<TextMesh>().color = Color.red;
        } else {
            Timer.GetComponent<TextMesh>().color = Color.black;
        }
    }
}
