using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public Transform wheelModel;
    
    [HideInInspector] public WheelCollider WheelCollider;

    public bool steerable;
    public bool motorized;

    Vector3 position;
    Quaternion rotation;


    // Start is called before the first frame update
    void Start()
    {
        WheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the wheel collider's world pose value
        WheelCollider.GetWorldPose(out position, out rotation);

        // Set wheel model's position and rotation
        wheelModel.transform.position = position;
        wheelModel.transform.rotation = rotation;
    }
}
