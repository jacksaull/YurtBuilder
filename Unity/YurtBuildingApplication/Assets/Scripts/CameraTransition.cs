using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {

    public string controlType;
    public Transform[] viewpoints;
    public float transitionSpeed;
    public GameObject CameraControls;
    Transform currentViewpoint;
    int desiredViewpoint;
    public Camera Cam;

	// Use this for initialization
	void Start()
    {
	}
	
	// Update is called once per frame
	void Update()
    {
        currentViewpoint = viewpoints[GetDesiredViewpoint()];
        if (desiredViewpoint == 2)
        {
            Cam.orthographic = true;
            Cam.orthographicSize = 15f;
            if (controlType == "Touch")
            {
                CameraControls.GetComponent<TouchCamera>().enabled = false;
            }
            else if (controlType == "Mouse")
            {
                CameraControls.GetComponent<MouseCamera>().enabled = false;
            }
            else { Debug.Log("Error: Camera Transition needs to know the Control type used, Mouse or Touch"); }
        }
        else {
            Cam.orthographic = false;
            if (controlType == "Touch")
            {
                CameraControls.GetComponent<TouchCamera>().enabled = true;
            }
            else if (controlType == "Mouse")
            {
                CameraControls.GetComponent<MouseCamera>().enabled = true;
            }
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentViewpoint.position, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentViewpoint.rotation, Time.deltaTime * transitionSpeed);
    }


    public int GetDesiredViewpoint()
    {
        return desiredViewpoint;
    }

    public void SetDesiredViewpoint(int v)
    {
        desiredViewpoint = v;
    }

}
