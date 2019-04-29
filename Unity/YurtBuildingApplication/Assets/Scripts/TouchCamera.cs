using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCamera : MonoBehaviour
{

    public Transform target;
    float distance = 20f;
    float maxDistance = 60f;
    float minDistance = 25f;
    float xSpeed = 200.0f;
    float ySpeed = 200.0f;
    int yMinLimit = -5;
    int yMaxLimit = 90;
    float zoomSpeed = 50.0f;
    //float panSpeed = 0.3f;
    float zoomDampening = 5.0f;

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

        // If using 1 finger, orbit around.
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchposition = Input.GetTouch(0).deltaPosition;
            xDeg += touchposition.x * xSpeed * 0.002f;
            yDeg -= touchposition.y * ySpeed * 0.002f;
            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
        }

        // If using 2 fingers, zoom in and out.
        if (Input.touchCount == 2)
        {
            Touch touchOne = Input.GetTouch(0);
            Touch touchTwo = Input.GetTouch(1);

            Vector2 touchOnePreviousPosition = touchOne.position - touchOne.deltaPosition;
            Vector2 touchTwoPreviousPosition = touchTwo.position - touchTwo.deltaPosition;

            float prevTouchDeltaMag = (touchOnePreviousPosition - touchTwoPreviousPosition).magnitude;
            float TouchDeltaMag = (touchOne.position - touchTwo.position).magnitude;

            float deltaMagDiff = prevTouchDeltaMag - TouchDeltaMag;

            desiredDistance += deltaMagDiff * Time.deltaTime * zoomSpeed * 0.0025f * Mathf.Abs(desiredDistance);
        }


        desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
        currentRotation = transform.rotation;
        rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
        transform.rotation = rotation;

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