using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;

public class RibArray : MonoBehaviour
{
    private int[] CheckRibs = new int[3];
    public GameObject[] Ribs;
    public Dropdown RibList;
    public Dropdown YurtList;
    public GameObject PopUp;
    public Button Remove;
    public Text YurtPiece;

    public GameObject SectionHandler;

    string YurtOption;
    string RibSelected;
    int usedRibs;
    int firstRib;
    int lastRib;
    int curRib;
    int sectionIndex;

    int selectedRib;

    void Start()
    {
        PopUp.SetActive(false);
        Remove.interactable = !Remove.interactable;
    }

    void Update()
    {

    }

    public void updateSelectedRib()
    {
        RibSelected = RibList.options[RibList.value].text;
        for (int n=0; n<40; n++)
        {
            if (Ribs[n].name == RibList.options[RibList.value].text)
            {
                Ribs[n].GetComponent<Renderer>().material.color = Color.yellow;
                YurtPiece.GetComponent<Text>().text = Ribs[n].GetComponent<RibPartName>().PartName;
                selectedRib = n;

                if (Ribs[n].GetComponent<RibPartName>().PartName == "Unavailable" && Remove.IsInteractable() == true)
                {
                    Remove.interactable = !Remove.interactable;
                }
                else if (Ribs[n].GetComponent<RibPartName>().PartName == "Free" && Remove.IsInteractable() == true)
                {
                    Remove.interactable = !Remove.interactable;
                }
                else if (Ribs[n].GetComponent<RibPartName>().PartName != "Unavailable" && Ribs[n].GetComponent<RibPartName>().PartName != "Free" && Remove.IsInteractable() == false)
                {
                    Remove.interactable = !Remove.interactable;
                }
            }

            if (Ribs[n].name != RibList.options[RibList.value].text && Ribs[n].tag != "Unavailable" && Ribs[n].tag != "Used")
            {
                Ribs[n].GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (Ribs[n].name != RibList.options[RibList.value].text && Ribs[n].tag == "Unavailable")
            {
                Ribs[n].GetComponent<Renderer>().material.color = Color.red;
            }
            else if (Ribs[n].name != RibList.options[RibList.value].text && Ribs[n].tag == "Used")
            {
                Ribs[n].GetComponent<Renderer>().material.color = Color.green;
            }
        }

    }
    public void updateSelectedYurtPiece()
    {
        Debug.Log(RibSelected);
        YurtOption = YurtList.options[YurtList.value].text;
        Debug.Log(YurtOption);

        if (YurtOption == "2 Rib Door")
        {
            usedRibs = 2;
            sectionIndex = 0;
        }
        else if (YurtOption == "3 Rib Door")
        {
            usedRibs = 3;
            sectionIndex = 1;
        }
        else if (YurtOption == "2 Rib Window")
        {
            usedRibs = 2;
            sectionIndex = 3;
        }

        for (int n = 0; n < 40; n++)
        {
            if (Ribs[n].name == RibSelected)
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

        for (int j = 0; j < usedRibs-1; j++)
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

    public void RemoveYurtSection()
    {
        int tmpGroupVal = Ribs[selectedRib].GetComponent<RibPartName>().groupNum;
        for (int i = 0; i < SectionHandler.GetComponent<SectionPlacer>().WallSections.Length; i++)
        {
            if(tmpGroupVal == SectionHandler.GetComponent<SectionPlacer>().WallSections[i].GetComponent<WallSectionHandler>().GroupNumber)
            {
                SectionHandler.GetComponent<SectionPlacer>().WallSections[i].GetComponent<MeshFilter>().mesh = SectionHandler.GetComponent<SectionPlacer>().ModelMeshes[4];
                SectionHandler.GetComponent<SectionPlacer>().WallSections[i].GetComponent<WallSectionHandler>().GroupNumber = 0;
                SectionHandler.GetComponent<SectionPlacer>().WallSections[i].GetComponent<WallSectionHandler>().PartName = "Free";
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

        Remove.interactable = !Remove.interactable;
    }
}
