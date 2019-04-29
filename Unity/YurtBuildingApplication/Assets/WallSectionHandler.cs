using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSectionHandler : MonoBehaviour
{
    public int GroupNumber;
    public string PartName;
    public Mesh[] ModelMeshes;

    // Start is called before the first frame update
    void Start()
    {
        GroupNumber = 0;
        PartName = "Free";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
