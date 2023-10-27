using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_DeliveryArea : MonoBehaviour
{

    private int deliveryScore;
    private int deliveryTarget;
    private bool gameOver;
    public GameObject UICounter; 
    public GameObject VictoryCamera;
    public GameObject FailureCamera;
    public GameObject PlayerCamera;
    public GameObject Timer;
    public GameObject SoundPlayer;
    private AudioSource SoundSource;
    public AudioClip WinSound;
    public AudioClip MusicSound;
    public AudioClip LoseSound;
    public AudioClip CollectSound;
    public AudioClip UnCollectSound;
    // Start is called before the first frame update
    void Start()
    {
        deliveryScore = 0;
        deliveryTarget = 8;
        gameOver = false;
        SoundSource = SoundPlayer.GetComponent<AudioSource>();
        UICounter.GetComponent<TextMesh>().text = "Organização: "+deliveryScore+"/"+deliveryTarget;
        ChangeCamera(1);
        InvokeRepeating("CheckTimeout", 0, 0.75f);
    }

    private void CheckTimeout()
    {
        if(!gameOver && Timer.GetComponent<TextMesh>().color == Color.black) {
            gameOver = true;
            ChangeCamera(3);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Delivery_Object") {
            deliveryScore++;
            UICounter.GetComponent<TextMesh>().text = "Organização: "+deliveryScore+"/"+deliveryTarget;
            CheckResult();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Delivery_Object") {
            deliveryScore--;
            UICounter.GetComponent<TextMesh>().text = "Organização: "+deliveryScore+"/"+deliveryTarget;
            SoundSource.PlayOneShot(UnCollectSound, 0.7f);
        }
    }

    private void ChangeCamera(int id = 1)
    {
        if(id == 2) { // Sucess
            SoundSource.clip = WinSound;
            SoundSource.volume = 0.25f;
            SoundSource.Play ();
            VictoryCamera.GetComponent<Camera>().enabled = (true);
            PlayerCamera.GetComponent<Camera>().enabled = (false);
            FailureCamera.GetComponent<Camera>().enabled = (false);
        } else if(id == 3) { // Failure 
            SoundSource.clip = LoseSound;
            SoundSource.volume = 1f;
            SoundSource.Play ();
            FailureCamera.GetComponent<Camera>().enabled = (true);
            PlayerCamera.GetComponent<Camera>().enabled = (false);
            VictoryCamera.GetComponent<Camera>().enabled = (false);
        } else { // Player Camera
            SoundSource.clip = MusicSound;
            SoundSource.volume = 1f;
            SoundSource.Play ();
            PlayerCamera.GetComponent<Camera>().enabled = (true);
            VictoryCamera.GetComponent<Camera>().enabled = (false);
            FailureCamera.GetComponent<Camera>().enabled = (false);
        }
    }

    private void CheckResult()
    {
        // Success
        if(!gameOver && deliveryScore == deliveryTarget) {
            gameOver = true;
            ChangeCamera(2);
        } else {
            SoundSource.PlayOneShot(CollectSound, 0.7f);
        }
    }
}
