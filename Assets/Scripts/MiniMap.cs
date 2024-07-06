using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    // public float cameraSpeed = 5.0f; // The speed at which the camera follows the player
    private Vector3 offset; // The initial offset between the camera and the player 

    void LateUpdate()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = playerTransform.position + offset;

        // Update the position of the mini map camera
        transform.position = targetPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
