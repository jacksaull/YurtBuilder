using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WallColour : MonoBehaviour
{
    public Material[] WallColours = new Material[3];
    public GameObject YurtWall;
    private string Colour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColour()
    {
        Colour = GetComponent<Button>().name;

        if (Colour == "Cream")
        {
            YurtWall.GetComponent<Renderer>().material = WallColours[0];
        }
        else if (Colour == "Sand")
        {
            YurtWall.GetComponent<Renderer>().material = WallColours[1];
        }
        else if (Colour == "Olive")
        {
            YurtWall.GetComponent<Renderer>().material = WallColours[2];
        }
    }
}
