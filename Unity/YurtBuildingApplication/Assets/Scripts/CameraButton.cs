using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButton : MonoBehaviour {

    public CameraTransition CameraTransition;
    public int buttonNumber;

    void Start()
    {
        //CameraTransition CT = mainCamera.GetComponent<CameraTransition>();
    }

    public void pressed()
    {
        CameraTransition.SetDesiredViewpoint(buttonNumber);
        Debug.Log("Pressed");
    }
}
