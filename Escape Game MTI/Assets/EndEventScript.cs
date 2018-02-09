using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEventScript : MonoBehaviour {
    public GameObject end;
    public GameObject screamer;

	// Use this for initialization
	void Start () {
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
	
}
