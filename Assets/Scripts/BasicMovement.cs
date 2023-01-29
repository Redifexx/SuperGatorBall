using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject camera;
    public float moveForce;
    public float stopForce;
    public float maxVerticalAngle;
    public float tiltSpeed;
    public float initialXRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        Vector3 forwardDir = camera.transform.forward;
        Vector3 rightDir = camera.transform.right;
        forwardDir.y = 0f;
        rightDir.y = 0f;
        forwardDir.Normalize();
        rightDir.Normalize();
        //float scaledVerticalTilt = initialXRotation - (scaledVerticalTilt * maxVerticalAngle);
        //Quaternion targetXRotation = Quaternion.Euler(scaledVerticalTilt, camera.transform.rotation.eulerAngles.y, camera.transform.rotation.eulerAngles.z);
        //camera.transform.rotation = Quaternion.RotateTowards(camera.transform.rotation, targetXRotation, tiltSpeed * Time.deltaTime);
        Vector3 DesiredDir = forwardDir * verticalAxis + rightDir * horizontalAxis;
        if (horizontalAxis == 0.0f && verticalAxis == 0.0f && rb.velocity.magnitude > 0.0f)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, stopForce * 0.1f * Time.deltaTime);
        }
        else
        {
            rb.AddForce(DesiredDir * moveForce * Time.deltaTime);
        }
    }
}
