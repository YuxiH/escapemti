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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        endButton.GetComponent<Button>().onClick.AddListener(Task);
        replayButton.GetComponent<Button>().onClick.AddListener(Task2);
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

     void Task()
    {
        Application.Quit();
    }

    void Task2()
    {
        Destroy(GameObject.Find("GameInfo"));
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
	
}
