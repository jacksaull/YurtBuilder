using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject tutPanel;
    public GameObject contactPanel;
    // Start is called before the first frame update
    void Start()
    {
        loadPanel.SetActive(false);
        tutPanel.SetActive(false);
        contactPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
