using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataImport : MonoBehaviour
{

    public TextAsset TextAssetData;
    

    [System.Serializable]

    
    public class IncidentData
    {
        public string name;
        public string in_desc;
        public float x;
        public float y;
        public int topic;
    }
    

    [System.Serializable]
    
    public class IncidentDataList
    {
        public IncidentData[] theList;

        // Set List
        public void setList(string fileName){
            
            // Read CSV
            List<Dictionary<string,object>> data = CSVReader.Read (fileName);
            Debug.Log("here new");
            
            // Initialize the Incident Data List - theList
            int dataSize = data.Count;
            theList = new IncidentData[dataSize];

            // Add each row the the list at an index
            for(var i=0; i < dataSize; i++) {

                /*Debug.Log("name " + data[i]["name"] + " " +
                    "incident " + data[i]["incident"] + " " +
                    "x " + (float)(data[i]["x"]) + " " +
                    "y " + (float)(data[i]["y"]) + " " +
                    "topic " + (int)(data[i]["topic"]));
                */
                theList[i] = new IncidentData();
                theList[i].name = (string)data[i]["names"];
                theList[i].in_desc = (string)data[i]["descriptions"];
                theList[i].x = (float)data[i]["x"];
                theList[i].y = (float)data[i]["y"];
                theList[i].topic = (int)data[i]["topic"];

                Debug.Log("name " + theList[i].name + " " +
                    "incident " + theList[i].in_desc + " " +
                    "x " + theList[i].x + " " +
                    "y " + theList[i].y + " " +
                    "topic " + theList[i].topic);
                
            }

            
        }

        // Get List
        public IncidentData[] getList(){
            return theList;
        }
    }


    public IncidentDataList newList = new IncidentDataList();
    
    
    // Start is called before the first frame update
    void Start()
    {
        newList.setList(TextAssetData.name);
        Debug.Log("here2 new");
        Debug.Log(TextAssetData.name);
    }
}
