using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

    public InputField input;
    public GameObject inp;
    public GameObject message;
    public bool end;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (other.GetComponent<PlayerScript>().keys < 4)
            {
                inp.SetActive(true);
                input.text = "Not enough keys";
            }
            else
            {
                end = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        inp.SetActive(false);
        input.text = "";
        input.placeholder.GetComponent<Text>().text = "";
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
