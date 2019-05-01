using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScript : MonoBehaviour
{
    public GameObject RibButtons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveSection()
    {
        for (int i = 0; i < RibButtons.GetComponent<RibButtonArray>().RibButtons.Length; i++)
        {
            RibButtons.GetComponent<RibButtonArray>().RibButtons[i].GetComponent<RibScript>().addPiece = false;
            RibButtons.GetComponent<RibButtonArray>().RibButtons[i].GetComponent<RibScript>().removePiece = true;
        }
    }
}
