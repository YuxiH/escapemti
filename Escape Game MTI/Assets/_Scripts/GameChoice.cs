using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameChoice : MonoBehaviour {

    public bool brave = false;
    public GameObject yesButton;
    public GameObject noButton;

    void Awake()
    {
        yesButton = GameObject.Find("YesButton");
        noButton = GameObject.Find("NoButton");
        yesButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        noButton.GetComponent<Button>().onClick.AddListener(TaskOnClick2);
        DontDestroyOnLoad(transform.gameObject);
    }

    void TaskOnClick()
    {
        brave = true;
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }

    void TaskOnClick2()
    {
        brave = false;
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
}
