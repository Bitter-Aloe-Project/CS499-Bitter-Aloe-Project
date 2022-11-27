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
                // incidentText = QueryIncidentText(topicIndex)
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
