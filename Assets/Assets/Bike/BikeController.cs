using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    [SerializeField] WheelCollider front;
    [SerializeField] WheelCollider back;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;
    [SerializeField] Transform frontTransform;
    [SerializeField] Transform backTransform;

    public LayerMask whatIsGround;
    bool grounded;
    public float playerHeight=2f;
    public float acceleration = 500f;
    public float brakingForce = 300f;

    private float currentAcc = 0f;
    private float currentBrakingForce = 0f;

    public float maxTurnAngle = 15f;
    private float currentTurnAngle = 0f;

    public Vector3 uprightTarget = Vector3.up;
    public float uprightTorque = 1f;

    //going upward
    public float liftForce = 500f;
    public Rigidbody bikeRigidbody;


    void Start()
    {
        // Set the center of mass for the bike's rigidbody
        // to be lower than the default value
        bikeRigidbody.centerOfMass = new Vector3(0, -0.55f, -0.3f);
    }



    void Update()
    {
        // grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f+0.2f, whatIsGround);
        // print(grounded);
        // if(grounded)
        // {    
            // Control the bike with W & S
            currentAcc = acceleration * Input.GetAxis("Vertical");  
        // } 
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            // GetComponent<Rigidbody>().AddTorque(-transform.right * xRotation *600f, ForceMode.Force);
             transform.Rotate(-Vector3.right, 100f * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            currentBrakingForce = brakingForce;
        }
        else
        {
            currentBrakingForce = 0f;
        }
 
        back.motorTorque = currentAcc;
        back.brakeTorque = currentBrakingForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        front.steerAngle = currentTurnAngle; 

        // Keep the bike upright
        var targetRotation = Quaternion.LookRotation(uprightTarget, transform.forward);
        var rotationDiff = Quaternion.FromToRotation(transform.up, uprightTarget);
        var torque = Vector3.Cross(transform.up, uprightTarget) * uprightTorque;
        GetComponent<Rigidbody>().AddTorque(torque, ForceMode.Force);
        GetComponent<Rigidbody>().angularVelocity *= 0.95f;

        // Clamp rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, uprightTorque * Time.fixedDeltaTime);
        
        turnWheel(front, frontTransform);
        turnWheel(back, backTransform);

        RotationCorrectionRight(frontTransform, backTransform);
    }

    private void RotationCorrectionRight(Transform front, Transform back)
    {
        Quaternion rotFront = front.rotation;
        Quaternion rotBack = back.rotation;
        rotFront = rotFront * Quaternion.Euler(0,-90,90);
        rotBack = rotBack * Quaternion.Euler(0,-90,90);
        front.rotation = rotFront;
        back.rotation = rotBack;
    }

    void turnWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        // set wheel transform state
        trans.position = position;
        trans.rotation = rotation;
    }
}
