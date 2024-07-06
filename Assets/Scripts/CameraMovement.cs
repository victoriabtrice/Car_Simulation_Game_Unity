using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject CarPlayer;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
       offset = transform.position - CarPlayer.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() 
    {
        // transform.position = CarPlayer.transform.position + offset;
        Vector3 targetPosition = CarPlayer.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        transform.rotation = CarPlayer.transform.rotation;
    }
}
