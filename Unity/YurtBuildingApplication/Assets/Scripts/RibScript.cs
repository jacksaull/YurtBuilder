using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RibScript : MonoBehaviour
{

    private string ribSelected;
    public string YurtOption;
    public bool addPiece;
    public bool removePiece;

    public RibArray RibArrayHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddOrRemove()
    {
        ribSelected = (GetComponent<Button>().name);

        if (addPiece == true)
        {
            RibArrayHandler.GetComponent<RibArray>().updateSelectedYurtPiece(YurtOption, ribSelected);
        }
        else if(removePiece == true)
        {
            RibArrayHandler.GetComponent<RibArray>().RemoveYurtSection(ribSelected);
        }
    }
}
