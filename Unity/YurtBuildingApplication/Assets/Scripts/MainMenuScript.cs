using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject nextMenuPanel;
    public Button nextMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLoadScreen()
    {
        if (nextMenuPanel.activeInHierarchy == true)
        {
            nextMenuPanel.SetActive(false);
        }
        else if (nextMenuPanel.activeInHierarchy == false)
        {
            nextMenuPanel.SetActive(true);
        }
    }
}
