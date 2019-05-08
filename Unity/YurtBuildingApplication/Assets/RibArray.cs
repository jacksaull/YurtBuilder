using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;

public class RibArray : MonoBehaviour
{
    private int[] CheckRibs = new int[4];
    public GameObject[] Ribs;
    public GameObject PopUp;

    public GameObject SectionHandler;

    string YurtOption;
    int usedRibs;
    int firstRib;
    int lastRib;
    int curRib;
    int sectionIndex;

    int selectedRib;

    void Start()
    {
        PopUp.SetActive(false);
    }

    void Update()
    {

    }

    public void updateSelectedYurtPiece(string YurtOption, string ribSelected)
    {
        Debug.Log(ribSelected);
        Debug.Log(YurtOption);

        if (YurtOption == "Single Curved")
        {
            usedRibs = 3;
            sectionIndex = 0;
        }
        else if (YurtOption == "Double Curved")
        {
            usedRibs = 4;
            sectionIndex = 1;
        }
        else if (YurtOption == "Single Porthole")
        {
            usedRibs = 3;
            sectionIndex = 2;
        }
        else if (YurtOption == "Single Full Window")
        {
            usedRibs = 3;
            sectionIndex = 3;
        }
        else if (YurtOption == "Framed Small")
        {
            usedRibs = 2;
            sectionIndex = 4;
        }
        else if (YurtOption == "Framed Medium")
        {
            usedRibs = 3;
            sectionIndex = 5;
        }
        else if (YurtOption == "Framed Large")
        {
            usedRibs = 4;
            sectionIndex = 6;
        }
        else if (YurtOption == "PVC Round")
        {
            usedRibs = 3;
            sectionIndex = 7;
        }
        else if (YurtOption == "PVC Square")
        {
            usedRibs = 3;
            sectionIndex = 8;
        }

        for (int n = 0; n < 40; n++)
        {
            if (Ribs[n].name == ribSelected)
            {
                firstRib = n;
                curRib = n;
            }
        }
        for (int j=0; j<usedRibs; j++)
        {
            CheckRibs[j] = curRib;

            if (Ribs[curRib].tag == "Unavailable")
            {
                PopUp.SetActive(true);
                return;
            }
            else if (Ribs[curRib].tag == "Used")
            {
                PopUp.SetActive(true);
                return;
            }
            else
            {
                curRib += 1;
                if (curRib > 39)
                {
                    curRib = 0;
                }
                lastRib = curRib;
                if (lastRib > 39)
                {
                    lastRib = 0;
                }
            }
         }
        int groupValue = Random.Range(1, 9999);
        for (int j = 0; j < usedRibs; j++)
        {
            int tmp = CheckRibs[j];
            Ribs[tmp].GetComponent<Renderer>().material.color = Color.green;
            Ribs[tmp].tag = "Used";
            Ribs[tmp].GetComponent<RibPartName>().PartName = YurtOption;
            Ribs[tmp].GetComponent<RibPartName>().groupNum = groupValue;
        }

        for (int j = 0; j < 1; j++)
        {
            int tmp = CheckRibs[j];

            SectionHandler.GetComponent<SectionPlacer>().ReplaceSections(tmp, sectionIndex, groupValue, YurtOption);
        }
        SectionHandler.GetComponent<SectionPlacer>().usedWalls = 0;

        curRib = lastRib;

        for (int j=0; j<3; j++)
         {
            Ribs[curRib].GetComponent<Renderer>().material.color = Color.red;
            Ribs[curRib].tag = "Unavailable";

            Ribs[curRib].GetComponent<RibPartName>().PartName = "Unavailable";
            Ribs[curRib].GetComponent<RibPartName>().Unv += 1;

            curRib += 1;
            if (curRib > 39)
            {
                curRib = 0;
            }
         }

        curRib = firstRib - 1;
        if (curRib < 0)
        {
            curRib = 39;
        }

        for (int j=0; j<3; j++)
         {
            Ribs[curRib].GetComponent<Renderer>().material.color = Color.red;
            Ribs[curRib].tag = "Unavailable";

            Ribs[curRib].GetComponent<RibPartName>().PartName = "Unavailable";
            Ribs[curRib].GetComponent<RibPartName>().Unv += 1;

            curRib -= 1;
            if (curRib < 0)
            {
                curRib = 39;
            }
         }
    }

    public void RemoveYurtSection(string ribSelected)
    {
        for (int n = 0; n < 40; n++)
        {
            if (Ribs[n].name == ribSelected)
            {
                selectedRib = n;
            }
        }

        int tmpGroupVal = Ribs[selectedRib].GetComponent<RibPartName>().groupNum;
        for (int i = 0; i < SectionHandler.GetComponent<SectionPlacer>().WallSections.Length; i++)
        {
            if(tmpGroupVal == SectionHandler.GetComponent<SectionPlacer>().WallSections[i].GetComponent<WallSectionHandler>().GroupNumber)
            {
                SectionHandler.GetComponent<SectionPlacer>().WallSections[i].GetComponent<MeshFilter>().mesh = SectionHandler.GetComponent<SectionPlacer>().ModelMeshes[9];
                SectionHandler.GetComponent<SectionPlacer>().WallSections[i].GetComponent<MeshRenderer>().materials = SectionHandler.GetComponent<SectionPlacer>().ModelRenderer[9].sharedMaterials;
                SectionHandler.GetComponent<SectionPlacer>().WallSections[i].GetComponent<WallSectionHandler>().GroupNumber = 0;
                SectionHandler.GetComponent<SectionPlacer>().WallSections[i].GetComponent<WallSectionHandler>().PartName = "Free";
                SectionHandler.GetComponent<SectionPlacer>().WallSections[i].SetActive(false);
            }
            if(tmpGroupVal == Ribs[i].GetComponent<RibPartName>().groupNum)
            {
                Ribs[i].GetComponent<Renderer>().material.color = Color.blue;
                Ribs[i].tag = "Empty";

                Ribs[i].GetComponent<RibPartName>().PartName = "Free";
                Ribs[i].GetComponent<RibPartName>().groupNum = 0;
                curRib = i;

                if (curRib == 39)
                {
                    curRib = -1;
                }
                if (Ribs[curRib+1].GetComponent<RibPartName>().PartName == "Unavailable")
                {
                    curRib += 1;
                    for(int j = 0; j < 3; j++)
                    {
                        Ribs[curRib].GetComponent<RibPartName>().Unv -= 1;
                        if(Ribs[curRib].GetComponent<RibPartName>().Unv == 0)
                        {
                            Ribs[curRib].GetComponent<Renderer>().material.color = Color.blue;
                            Ribs[curRib].tag = "Empty";

                            Ribs[curRib].GetComponent<RibPartName>().PartName = "Free";
                            Ribs[curRib].GetComponent<RibPartName>().groupNum = 0;
                        }

                        curRib += 1;
                        if (curRib > 39)
                        {
                            curRib = 0;
                        }
                    }
                }

                curRib = i;
                if (curRib == 0)
                {
                    curRib = 40;
                }
                if (Ribs[curRib-1].GetComponent<RibPartName>().PartName == "Unavailable")
                {
                    curRib -= 1;
                    for (int j = 0; j < 3; j++)
                    {
                        Ribs[curRib].GetComponent<RibPartName>().Unv -= 1;
                        if (Ribs[curRib].GetComponent<RibPartName>().Unv == 0)
                        {
                            Ribs[curRib].GetComponent<Renderer>().material.color = Color.blue;
                            Ribs[curRib].tag = "Empty";

                            Ribs[curRib].GetComponent<RibPartName>().PartName = "Free";
                            Ribs[curRib].GetComponent<RibPartName>().groupNum = 0;
                        }

                        curRib -= 1;
                        if (curRib < 0)
                        {
                            curRib = 39;
                        }
                    }
                }
            }
        }
    }
}
