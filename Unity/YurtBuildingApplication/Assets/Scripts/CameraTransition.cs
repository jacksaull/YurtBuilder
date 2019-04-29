using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {


    public Transform[] viewpoints;
    public float transitionSpeed;
    Transform currentViewpoint;
    //bool test = true;
    int desiredViewpoint;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        /*
        if (test)
        {
            currentViewpoint = viewpoints[0];
        }
        else if (!test)
        {
            currentViewpoint = viewpoints[1];
        }
        */
        currentViewpoint = viewpoints[GetDesiredViewpoint()];


	}

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentViewpoint.position, Time.deltaTime * transitionSpeed);
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
