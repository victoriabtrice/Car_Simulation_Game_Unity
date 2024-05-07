using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float motorTorque = 96000; //2000
    public float brakeTorque = 96000; //2000
    public float maxSpeed = 20000; //20
    public float steeringRange = 30; //30
    public float steeringRangeAtMaxSpeed = 10; //10
    public float centerOfGravityOffset = -2f;
    public float speed;
    private int count;
    public Text countPoint;

    Rigidbody rigidBody;
    WheelController[] wheels;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.centerOfMass += Vector3.up * centerOfGravityOffset;
        wheels = GetComponentsInChildren<WheelController>();
        count = 0;
        CountPoint();
    }

    // Update is called once per frame
    void Update()
    {
        float moveV = Input.GetAxis("Vertical");
        float moveH = Input.GetAxis("Horizontal");

        // Calculate current speed in relation to the forward direction (backward = negative number)
        float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);

        // Calculate how close the car to top speed (from 0 to 1)
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);

        // Calculate how much torque is available
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);

        // Calculate how much to steer
        float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);


        bool isAccelerate = Mathf.Sign(moveV) == Mathf.Sign(forwardSpeed);
        foreach(var wheel in wheels){
            // Apply steer to wheel colliders that have steerable enabled
            if(wheel.steerable){
                wheel.WheelCollider.steerAngle = moveH * currentSteerRange;
            }
            if(isAccelerate){
                // Apply torque to wheel colliders that have motorized enabled
                if(wheel.motorized){
                    wheel.WheelCollider.motorTorque = moveV * currentMotorTorque;
                }
                wheel.WheelCollider.brakeTorque = 0;
            } else {
                // if user trying to go opposite direction, apply brake to all wheels
                wheel.WheelCollider.brakeTorque = Mathf.Abs(moveV) * brakeTorque;
                wheel.WheelCollider.motorTorque = 0;
            }
        }

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "silverCoin"){
            other.gameObject.SetActive(false);
            count = count+5;
            CountPoint();
        }
        if(other.gameObject.tag == "hazard"){
            // other.gameObject.SetActive(false);
            // Vector3 jump = new Vector3(0.0f, 5, 0.0f);
            // GetComponent<Rigidbody>().AddForce(jump*speed*Time.deltaTime, ForceMode.Impulse);
            count = count-5;
            CountPoint();
        }
    }

    void CountPoint() {
        countPoint.text = "Point: " + count.ToString();
    }
}
