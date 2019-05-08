using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FloorMaterial : MonoBehaviour
{
    public Material[] FloorMaterials = new Material[3];
    public GameObject YurtFloor;
    private string Materials;
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
        Materials = GetComponent<Button>().name;

        if (Materials == "Carpet")
        {
            YurtFloor.GetComponent<Renderer>().material = FloorMaterials[0];
        }
        else if (Materials == "Hardwood")
        {
            YurtFloor.GetComponent<Renderer>().material = FloorMaterials[1];
        }
        else if (Materials == "Spiderweb")
        {
            YurtFloor.GetComponent<Renderer>().material = FloorMaterials[2];
        }
    }
}
