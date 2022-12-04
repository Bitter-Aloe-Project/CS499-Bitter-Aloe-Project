using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public List<int> chosenTopics = new List<int>();
    Toggle toggledButton;
    //get the toggle component on start
    void Start()
    {
        toggledButton.GetComponent<Toggle>();
    }

    //takes the player to the first scene and starts the game
   public void startScene()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /*used in debugging
    public void chooseTopic()
    {
        if(toggledButton.isOn)
        Debug.Log("the topic chosen: ");
    }
    */
}
