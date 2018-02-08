using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

    private GameObject player;
    private GameObject input;
    public bool end;
    public int total;

    void Start()
    {
        player = GameObject.Find("Player");
        input = player.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (other.GetComponent<PlayerScript>().keys < total)
            {
                input.GetComponent<TextController>().enableText("Keys needed: (" + player.GetComponent<PlayerScript>().keys + "/" + total + ")");
            }
            else
            {
                end = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        input.GetComponent<TextController>().disableInput();
    }

}
