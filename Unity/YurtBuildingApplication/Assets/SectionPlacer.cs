using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class SectionPlacer : MonoBehaviour
{
    public GameObject[] WallSections;
    public Mesh[] ModelMeshes;
    public int usedWalls = 0;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ReplaceSections(int ribIndex, int sectionIndex, int groupValue, string YurtPiece)
    {
        if (YurtPiece == "2 Rib Door")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "2 Rib Door";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex + usedWalls];
            usedWalls++;
        }
        else if (YurtPiece == "3 Rib Door")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "3 Rib Door";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex + usedWalls];
            usedWalls++;
        }
        else if (YurtPiece == "2 Rib Window")
        {
            WallSections[ribIndex].GetComponent<WallSectionHandler>().GroupNumber = groupValue;
            WallSections[ribIndex].GetComponent<WallSectionHandler>().PartName = "2 Rib Window";

            WallSections[ribIndex].GetComponent<MeshFilter>().mesh = ModelMeshes[sectionIndex + usedWalls];
            usedWalls++;
        }
    }
}
