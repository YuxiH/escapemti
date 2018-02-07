using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {

    private GameObject player;
    private InputField input;
    private GameObject inp;
    public bool end;

    void Start()
    {
        player = GameObject.Find("Player");
        inp = player.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        input = inp.GetComponent<InputField>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (other.GetComponent<PlayerScript>().keys < 4)
            {
                inp.SetActive(true);
                input.DeactivateInputField();
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
        input.ActivateInputField();
        inp.SetActive(false);
        input.text = "";
        input.placeholder.GetComponent<Text>().text = "";
    }

}
