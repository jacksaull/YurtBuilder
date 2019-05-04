using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoofColour : MonoBehaviour
{
    public Material[] RoofColours = new Material[3];
    public GameObject YurtRoof;
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
            YurtRoof.GetComponent<Renderer>().material = RoofColours[0];
        }
        else if (Colour == "Sand")
        {
            YurtRoof.GetComponent<Renderer>().material = RoofColours[1];
        }
        else if (Colour == "Olive")
        {
            YurtRoof.GetComponent<Renderer>().material = RoofColours[2];
        }
    }
}
