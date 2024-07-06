using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float motorTorque = 96000 * 4 * 4; //2000
    public float brakeTorque = 96000 * 4 * 4; //2000
    public float maxSpeed = 20000 * 3.5f * 4; //20
    public float steeringRange = 30 * 1.5f; //30
    public float steeringRangeAtMaxSpeed = 10 * 1.5f; //10
    public float centerOfGravityOffset = -2f;
    public float forwardSpeed;
    public int count;
    public int crash;
    public int crashtime;
    public Text countPoint;
    public Text speedText;

    Rigidbody rigidBody;
    WheelController[] wheels;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.centerOfMass += Vector3.up * centerOfGravityOffset;
        wheels = GetComponentsInChildren<WheelController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        countPoint = GameObject.Find("CountPoint").GetComponent<Text>();
        speedText = GameObject.Find("Speed").GetComponent<Text>();
        count = 0;
        // crash = 0;
        crashtime = 0;
        CountPoint();
    }

    // Update is called once per frame
    void Update()
    {
        DisplaySpeed();

        float moveV = Input.GetAxis("Vertical");
        float moveH = Input.GetAxis("Horizontal");

        // Calculate current speed in relation to the forward direction (backward = negative number)
        forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity * 2.5f);

        PlayerPrefs.SetFloat("SpeedValue", forwardSpeed);

        if(count > 0){
            forwardSpeed *= count;
        }

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
            // crash = -5;
            crashtime += 1;
            PlayerPrefs.SetInt("CrashValue", crashtime);
        }
    }

    void CountPoint() {
        countPoint.text = "Point: " + count.ToString();
        PlayerPrefs.SetInt("PointValue", count);
    }

    void DisplaySpeed() {
        speedText.text = "Speed: " + Mathf.Round(forwardSpeed * Time.deltaTime * 100) + " m/s";
    }
}
