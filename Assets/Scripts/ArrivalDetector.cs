using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrivalDetector : MonoBehaviour
{
    // public Transform destinationPosition;
    public GameObject messagePanel;

    // Start is called before the first frame update
    void Start()
    {
        messagePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        { 
            messagePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
