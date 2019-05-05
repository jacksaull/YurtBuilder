using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{

    public Transform target;

    private float mouseSensitivity = 4f;
    private float scrollSensitivity = 2f;
    private float distance;
    private float maxDistance = 60f;
    private float minDistance = 34f;
    private int yMinLimit = -10;
    private int yMaxLimit = 90;
    private float zoomDampening = 5.0f;
    private float xDeg = 0.0f;
    private float yDeg = 0.0f;
    private float currentDistance;
    private float desiredDistance;
    private Quaternion currentRotation;
    private Quaternion desiredRotation;
    private Quaternion rotation;
    private Vector3 position;

    void Start()
    {
        distance = Vector3.Distance(transform.position, target.position);
        currentDistance = distance;
        desiredDistance = distance;
        position = transform.position;
        rotation = transform.rotation;
        currentRotation = transform.rotation;
        desiredRotation = transform.rotation;

        xDeg = Vector3.Angle(Vector3.right, transform.right);
        yDeg = Vector3.Angle(Vector3.up, transform.up);
    }


    void LateUpdate()
    {

        // If moving mouse
        if (Input.GetAxis("Mouse X") != 0 && Input.GetMouseButton(0) || Input.GetAxis("Mouse Y") != 0 && Input.GetMouseButton(0))
        {
            //Vector2 touchposition = Input.GetTouch(0).deltaPosition;
            xDeg += Input.GetAxis("Mouse X") * mouseSensitivity;
            yDeg -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
        }

        // If scrolling mouse wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            desiredDistance -= scrollSensitivity;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            desiredDistance += scrollSensitivity;
        }


        // Handles rotation
        desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
        currentRotation = transform.rotation;
        rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
        transform.rotation = rotation;

        //Handles zooming
        desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);
        position = target.position - (rotation * Vector3.forward * currentDistance);
        transform.position = position;

    }


    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}