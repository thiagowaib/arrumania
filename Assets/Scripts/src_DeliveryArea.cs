using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class src_DeliveryArea : MonoBehaviour
{

    private int deliveryScore;
    private int deliveryTarget;
    public GameObject UICounter; 
    // Start is called before the first frame update
    void Start()
    {
        deliveryScore = 0;
        deliveryTarget = 2;
        UICounter.GetComponent<TextMesh>().text = "Organização: "+deliveryScore+"/"+deliveryTarget;
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
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Delivery_Object") {
            deliveryScore--;
            UICounter.GetComponent<TextMesh>().text = "Organização: "+deliveryScore+"/"+deliveryTarget;
        }
    }
}
