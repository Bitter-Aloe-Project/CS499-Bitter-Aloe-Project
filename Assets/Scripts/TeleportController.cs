using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TeleportController : MonoBehaviour
{
    public GameObject player;
    public int level;
    public float interactRadius;
    public TextMeshProUGUI interactText;

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
            if (props.interactingWith != 0 && props.interactingWith != level) return;
            props.interactingWith = level;
            interactText.text = "Press [E] to interact with the teleporter!";

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(sceneBuildIndex:level);
            }
        } 
        else 
        {
            if (props.interactingWith == level && interactText.text != "")
            {
                interactText.text = "";
                props.interactingWith = 0;
            }    
        }
    }
}
