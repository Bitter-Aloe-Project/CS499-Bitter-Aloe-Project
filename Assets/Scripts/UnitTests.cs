using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitTests
{

    public void Tests(){
        
        string fname = DataImport.newList.getFileName();

        // Check The Headers are correct        
        string[] header = CSVReader.readHeader(fname);
        bool headerCells = (header[0]=="names" && header[1]=="descriptions" && header[2]=="x" && header[3]=="y" && header[4]=="topic");
        Debug.Assert(header.Length==5, "There should be five table header cells: names, descriptions, x, y, and topics. There are currently more/less then 5.");
        Debug.Assert(headerCells, "There should be five table header cells: names, descriptions, x, y, and topics. The headers are currently not matching.");

        // Check the correct data is read 
        IncidentDataList TestList = new IncidentDataList();  
        TestList.setList("Test_Data");
        Debug.Assert(TestList.getIncident(0).name=="ASMAN, Roockea", "Name not read correctly.");
        Debug.Assert(TestList.getIncident(0).in_desc=="An ANC supporter who had her house burnt down on 20 March 1994 in Sonkombo, Ndwedwe, KwaZulu, near Durban, in intense political conflict in the area. See Sonkombo arson attacks.", "Description not read correctly.");
        Debug.Assert(Math.Abs(TestList.getIncident(0).x - 9.540363) < 0.05, "X not read correctly.");
        Debug.Assert(Math.Abs(TestList.getIncident(0).y - 14.279837)< 0.05, "Y not read correctly.");
        Debug.Assert(TestList.getIncident(0).topic==0, "Topic not read correctly.");

        // Check the methods result in correct returns
        HashSet<int> testTopics = new HashSet<int>(); testTopics.Add(0); testTopics.Add(1);
        Debug.Assert(TestList.getTopics().SetEquals(testTopics), "Topics not queried correctly.");
        Debug.Assert(TestList.getTopicBegin(0)==0, "Get the Topic Begin working incorrectly.");
        Debug.Assert(TestList.getTopicBegin(1)==1, "Get the Topic Begin working incorrectly.");
        Debug.Assert(TestList.getTopicEnd(0)==0, "Get the Topic End working incorrectly.");
        Debug.Assert(TestList.getTopicEnd(1)==1, "Get the Topic End working incorrectly.");
        

    }

}
