using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class floatScript : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backLeft;
    // check if on water
    public LayerMask whatIsWater;
    bool onWater;
    public float playerHeight;

    public float acceleration = 500f;
    public float brakingForce = 300f;

    private float currentAcc = 0f;
    private float currentBrakingForce = 0f;

    public float maxTurnAngle = 15f;
    private float currentTurnAngle = 0f;

    void Update()
    {
        onWater = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f+0.2f, whatIsWater);
        if(onWater)
        {
            // print("you are on water");
            currentAcc = acceleration * Input.GetAxis("Vertical");
            if(Input.GetKey(KeyCode.Space))
            {
                currentBrakingForce = brakingForce;
            }
            else
            {
                currentBrakingForce = 0f;
            }
    
            backLeft.motorTorque = currentAcc;
            backRight.motorTorque = currentAcc;
            backRight.brakeTorque = currentBrakingForce;
            backLeft.brakeTorque = currentBrakingForce;

            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
            frontRight.steerAngle = currentTurnAngle;
            frontLeft.steerAngle = currentTurnAngle; 
        }else{
            // print("you are not on water");
        }

    }
}
