using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScript : MonoBehaviour
{
    public GameObject RibButtons;
    private string YurtOption;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSection()
    {
        YurtOption = (GetComponent<Button>().name);

        for(int i = 0; i < RibButtons.GetComponent<RibButtonArray>().RibButtons.Length; i++)
        {
            RibButtons.GetComponent<RibButtonArray>().RibButtons[i].GetComponent<RibScript>().addPiece = true;
            RibButtons.GetComponent<RibButtonArray>().RibButtons[i].GetComponent<RibScript>().removePiece = false;
            RibButtons.GetComponent<RibButtonArray>().RibButtons[i].GetComponent<RibScript>().YurtOption = YurtOption;
        }
    }
}
