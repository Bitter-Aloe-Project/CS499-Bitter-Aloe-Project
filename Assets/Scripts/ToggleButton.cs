using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ToggleButton : MonoBehaviour
{
    Toggle toggledButtton;
    private GameObject topicSelect;
  

    void Start()
    {
        //get all the components at start
        toggledButtton = GetComponent<Toggle>();
        toggledButtton.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggledButtton);
        });


        Debug.Log("Toggle is :" + toggledButtton.isOn);
    }

    //if button is toggled on Toggle value is true and the name of the button is converted to an int and stored in a list
    void ToggleValueChanged(Toggle change)
    {
        if(toggledButtton.isOn == true)
        {
            Debug.Log("add " + int.Parse(toggledButtton.name) + " to array");
            topicSelect = GameObject.Find("SceneSelector");
            SceneSelector temp = topicSelect.GetComponent<SceneSelector>();
            temp.chosenTopics.Add(int.Parse(toggledButtton.name));
            string theList = "List Contains: ";
            foreach (int aTopic in temp.chosenTopics)
            {
                theList += aTopic + ", ";
            }
            Debug.Log(theList);
        }
        //if a button is selected again or "toggled off" the Toggle value is set back to false and the int associated with the button is removed from the list
        else
        {
            Debug.Log("Remove " + int.Parse(toggledButtton.name) + " from array");
            topicSelect = GameObject.Find("SceneSelector");
            SceneSelector temp = topicSelect.GetComponent<SceneSelector>();
            temp.chosenTopics.Remove(int.Parse(toggledButtton.name));
            string theList = "List Contains: ";
            foreach (int aTopic in temp.chosenTopics)
            {
                theList += aTopic + ", ";
            }
            Debug.Log(theList);

        }
        
    }
}
