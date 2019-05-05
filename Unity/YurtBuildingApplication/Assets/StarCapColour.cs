using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StarCapColour : MonoBehaviour
{
    public Material[] StarCapColours = new Material[5];
    public GameObject YurtStarCap;
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
            YurtStarCap.GetComponent<Renderer>().material = StarCapColours[0];
        }
        else if (Colour == "Sand")
        {
            YurtStarCap.GetComponent<Renderer>().material = StarCapColours[1];
        }
        else if (Colour == "Olive")
        {
            YurtStarCap.GetComponent<Renderer>().material = StarCapColours[2];
        }
        else if (Colour == "Burgundy")
        {
            YurtStarCap.GetComponent<Renderer>().material = StarCapColours[3];
        }
        else if (Colour == "Blue")
        {
            YurtStarCap.GetComponent<Renderer>().material = StarCapColours[4];
        }
    }
}
