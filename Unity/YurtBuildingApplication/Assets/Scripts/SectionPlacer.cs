using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class SectionPlacer : MonoBehaviour
{
    public GameObject[] WallSections;
    public Mesh[] ModelMeshes;
    public MeshRenderer[] ModelRenderer;
    public int usedWalls = 0;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ReplaceSections(int ribIndex, int sectionIndex, int groupValue, string YurtPiece)
    {
        if (YurtPiece == "Single Curved")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "Single Curved";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex];
            WallSections[ribIndex].GetComponent<MeshRenderer>().materials = ModelRenderer[sectionIndex].sharedMaterials;
            WallSections[ribIndex].SetActive(true);
        }
        else if (YurtPiece == "Double Curved")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "Double Curved";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex];
            WallSections[ribIndex].GetComponent<MeshRenderer>().materials = ModelRenderer[sectionIndex].sharedMaterials;
            WallSections[ribIndex].SetActive(true);
        }
        else if (YurtPiece == "Single Porthole")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "Single Porthole";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex];
            WallSections[ribIndex].GetComponent<MeshRenderer>().materials = ModelRenderer[sectionIndex].sharedMaterials;
            WallSections[ribIndex].SetActive(true);
        }
        else if (YurtPiece == "Single Full Window")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "Single Full Window";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex];
            WallSections[ribIndex].GetComponent<MeshRenderer>().materials = ModelRenderer[sectionIndex].sharedMaterials;
            WallSections[ribIndex].SetActive(true);
        }
        else if (YurtPiece == "Framed Small")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "Framed Small";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex];
            WallSections[ribIndex].GetComponent<MeshRenderer>().materials = ModelRenderer[sectionIndex].sharedMaterials;
            WallSections[ribIndex].SetActive(true);
        }
        else if (YurtPiece == "Framed Medium")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "Framed Medium";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex];
            WallSections[ribIndex].GetComponent<MeshRenderer>().materials = ModelRenderer[sectionIndex].sharedMaterials;
            WallSections[ribIndex].SetActive(true);
        }
        else if (YurtPiece == "Framed Large")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "Framed Large";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex];
            WallSections[ribIndex].GetComponent<MeshRenderer>().materials = ModelRenderer[sectionIndex].sharedMaterials;
            WallSections[ribIndex].SetActive(true);
        }
        else if (YurtPiece == "PVC Round")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "PVC Round";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex];
            WallSections[ribIndex].GetComponent<MeshRenderer>().materials = ModelRenderer[sectionIndex].sharedMaterials;
            WallSections[ribIndex].SetActive(true);
        }
        else if (YurtPiece == "PVC Square")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "PVC Square";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex];
            WallSections[ribIndex].GetComponent<MeshRenderer>().materials = ModelRenderer[sectionIndex].sharedMaterials;
            WallSections[ribIndex].SetActive(true);
        }
    }
}
