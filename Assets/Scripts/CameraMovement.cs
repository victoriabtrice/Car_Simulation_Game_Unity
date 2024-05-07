using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject CarPlayer;
    private Vector3 offset;
    // public float smoothSpeed = 0.125f;
    // Vector3 velocity = Vector3.zero;

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
        transform.position = CarPlayer.transform.position + offset;
        // Vector3 smoothPosition = Vector3.Lerp(transform.position, position, smoothSpeed * Time.deltaTime);
        // transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, smoothSpeed);
        // transform.LookAt(CarPlayer.transform);
    }
}
