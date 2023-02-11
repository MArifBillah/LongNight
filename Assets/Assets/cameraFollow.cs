using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    float distance;
    Vector3 playerPrevPos, playerMoveDir;

    // Use this for initialization
    void Start () {
    offset = transform.position - target.position;

    distance = offset.magnitude;
    playerPrevPos = target.position;
    }

    void LateUpdate ()
    {
        Vector3 transPosition = transform.position;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        // transform.LookAt(target);
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

    }

}
