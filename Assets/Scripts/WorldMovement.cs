using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [SerializeField] private float _maxAngle = 45;
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _rotation;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalTilt = Input.GetAxis("Horizontal");
        float horizontalTilt = Input.GetAxis("Vertical");
        Vector3 forwardDir = camera.transform.forward;
        Vector3 rightDir = camera.transform.right;
        forwardDir.y = 0f;
        rightDir.y = 0f;
        forwardDir.Normalize();
        rightDir.Normalize();

        Vector3 DesiredDir = forwardDir * verticalTilt + rightDir * horizontalTilt;

        //float verticalTilt = Input.GetAxis("Vertical");
        //float horizontalTilt = Input.GetAxis("Horizontal");
        // Vector3 m = new Vector3(verticalTilt, 0, -horizontalTilt);
        /*
        if(transform.eulerAngles.x < _maxAngle)
        {
            transform.Rotate(-Vector3.right*(_rotation));
        }
        else if(transform.eulerAngles.x > _maxAngle)
        {
            transform.Rotate(Vector3.right * (_rotation));
        }*/
        if (horizontalTilt != 0 || verticalTilt != 0)
        {
            transform.Rotate(DesiredDir * _speed * Time.deltaTime);
            LimitRotationXYZ();
        }
        else
        { transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, _speed * Time.deltaTime); }

    }

    void LimitRotationX()
    {
        Vector3 worldAngle = transform.rotation.eulerAngles;
        worldAngle.x = (worldAngle.x > 180) ? worldAngle.x - 360 : worldAngle.x;
        worldAngle.x = Mathf.Clamp(worldAngle.x, -_maxAngle, _maxAngle);
        transform.rotation = Quaternion.Euler(worldAngle);
    }
    void LimitRotationY()
    {
        Vector3 worldAngle = transform.rotation.eulerAngles;
        worldAngle.y = (worldAngle.y > 180) ? worldAngle.y - 360 : worldAngle.x;
        worldAngle.y = Mathf.Clamp(worldAngle.y, -_maxAngle, _maxAngle);
        transform.rotation = Quaternion.Euler(worldAngle);
    }
    void LimitRotationZ()
    {
        Vector3 worldAngle = transform.rotation.eulerAngles;
        worldAngle.z = (worldAngle.z > 180) ? worldAngle.z - 360 : worldAngle.z;
        worldAngle.z = Mathf.Clamp(worldAngle.z, -_maxAngle, _maxAngle);
        transform.rotation = Quaternion.Euler(worldAngle);
    }
    void LimitRotationXYZ()
    {
        LimitRotationX();
        //LimitRotationY();
        LimitRotationZ();
    }
}
