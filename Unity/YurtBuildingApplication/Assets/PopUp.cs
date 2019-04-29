using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Button PopUpButton;
    public GameObject PopUpPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ClosePopUp()
    {
        PopUpPanel.SetActive(false);
    }
}
