using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleportController : MonoBehaviour
{
    public GameObject player;
    public int topicIndex;
    public float interactRadius;
    public TextMeshProUGUI interactText;
    public GameObject incidentPanel;
    public TextMeshProUGUI incidentText;
    public int topicChoice;

    PlayerProperties props;
    // Start is called before the first frame update
    void Start()
    {
        props = player.GetComponent<PlayerProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < interactRadius)
        {
            if (props.interactingWith != 0 && props.interactingWith != topicIndex) return;
            props.interactingWith = topicIndex;
            interactText.text = "Press [E] to learn more!";

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (incidentPanel != null) {
                    incidentPanel.SetActive(true);
                }
                //To find an incident based on the topic
                //IncidentData incident = DataImport.newList.getIncident(UnityEngine.Random.Range(DataImport.newList.getTopicBegin(topicChoice), DataImport.newList.getTopicEnd(topicChoice)));
                IncidentData incident = DataImport.newList.getIncident(UnityEngine.Random.Range(0, DataImport.newList.dataSize));
                incidentText.text = incident.topic + " "  + incident.name + " " + incident.in_desc;

                //Debug.Log(DataImport.newList.getTopicEnd(topicChoice));
                Debug.Log(topicIndex);
                Debug.Log(incident.name + " INCIDENT TEXT: " + incidentText.text);
                //string incidentPersonName = incident.name;
                //float inc_x_cord = incident.x;
                //float inc_y_cord = incident.y;
                //int inc_topic = incident.topic;
            }
        } 
        else 
        {
            if (props.interactingWith == topicIndex && interactText.text != "")
            {
                interactText.text = "";
                props.interactingWith = 0;
                if (incidentPanel != null) {
                    incidentPanel.SetActive(false);
                }
            }    
        }
    }
}
