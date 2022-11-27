using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{

    public TextAsset TextAssetData;
    // Start is called before the first frame update
    void Start()
    {
        DataImport.newList.setList(TextAssetData.name);
        Debug.Log("here2 new");
        Debug.Log(TextAssetData.name);
        DataImport.newList.getTopics();
    }

}
