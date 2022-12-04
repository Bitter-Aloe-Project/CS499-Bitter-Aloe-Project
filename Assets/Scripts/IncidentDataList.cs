using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncidentDataList 
{
    public IncidentData[] theList;
    public int dataSize;
    public string fileName;

    // Set List 
    // Gets Data from the .CSV file and stores it in to a list - theList
    public void setList(string fileName){
        
        // Read CSV
        List<Dictionary<string,object>> data = CSVReader.Read (fileName);
        Debug.Log("here new");
        
        // Initialize the Incident Data List - theList
        dataSize = data.Count;
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
            theList[i].inc_index = (int) i;
            theList[i].name = (string)data[i]["names"];
            theList[i].in_desc = (string)data[i]["descriptions"];
            theList[i].x = (float)data[i]["x"];
            theList[i].y = (float)data[i]["y"];
            theList[i].topic = (int)data[i]["topic"];

            /*Debug.Log("inc_index " + theList[i].inc_index + " " + 
                "name " + theList[i].name + " " +
                "incident " + theList[i].in_desc + " " +
                "x " + theList[i].x + " " +
                "y " + theList[i].y + " " +
                "topic " + theList[i].topic);
            */
        }

        
    }

    // Get List
    public IncidentData[] getList(){
        return theList;
    }

    // Get Topics
    // Returns the set of topics from the list
    public HashSet<int> getTopics(){
        
        HashSet<int> topics = new HashSet<int>();
        
        for(int i=0; i < theList.Length; i++){
            topics.Add(theList[i].topic);
        }

        //foreach (var item in topics) {
        //    Debug.Log(item);
        //}

        return topics;

    }

    // Get Incident
    public IncidentData getIncident(int index){
        
        for (int i=0; i < theList.Length; i++){
            if (theList[i].inc_index == index){
                return theList[i];
            }
        }

        IncidentData notFound = new IncidentData();
        notFound.inc_index = -1;

        Debug.Log("No Incident Found Associated with Index " + index);

        return notFound;
    }

    //GetTopic
    public int getTopicBegin(int topicChoice)
    {
        for (int i = 0; i < theList.Length; i++)
        {
            if (theList[i].topic == topicChoice)
            {
                return i;
            }
        }

        return -1;
        //IncidentData notFound = new IncidentData();
        //notFound.inc_index = -1;

        //Debug.Log("No Incident Found Associated with Index " + topicChoice);

        //return notFound;
    }

    public int getTopicEnd(int topicChoice)
    {
        for (int i = getTopicBegin(topicChoice); i < theList.Length; i++)
        {
            if (i+i>=theList.Length){
                return (theList.Length-1);
            }    
            else if (theList[i + 1].topic != topicChoice)
            {
                return i;
            }
            
        }

        return -1;
/*
        IncidentData notFound = new IncidentData();
        notFound.inc_index = -1;

        Debug.Log("No Incident Found Associated with Index " + topicChoice);

        return notFound;
*/
    }

    public void setFileName(string fname){
        fileName = fname;
    }

    public string getFileName(){
        return fileName;
    }

}
