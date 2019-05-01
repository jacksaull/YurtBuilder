using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {


    public Transform[] viewpoints;
    public float transitionSpeed;
    public GameObject TouchControls;
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
        if(desiredViewpoint == 2)
        {
            TouchControls.GetComponent<TouchCamera>().enabled = false;
            Cam.orthographic = true;
            Cam.orthographicSize = 15f;
        }
        else
        {
            TouchControls.GetComponent<TouchCamera>().enabled = true;
            Cam.orthographic = false;
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
