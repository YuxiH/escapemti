using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndEventScript : MonoBehaviour {
    private GameObject end;
    private GameObject screamer;
    public GameObject endButton;
    public GameObject replayButton;

	// Use this for initialization
	void Start () {
        endButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        replayButton.GetComponent<Button>().onClick.AddListener(TaskOnClick2);
        end = GameObject.Find("The end");
        screamer = GameObject.Find("Screamer");
        GameObject choice = GameObject.Find("GameInfo");
        if (choice.GetComponent<GameChoice>().brave)
        {
            end.SetActive(false);
            screamer.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            end.SetActive(true);
            screamer.SetActive(false);
        }
	}

     void TaskOnClick()
    {
        Application.Quit();
    }

    void TaskOnClick2()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
	
}
