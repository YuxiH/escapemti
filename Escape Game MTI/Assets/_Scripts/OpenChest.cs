using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour {

    public string solution;
    private GameObject player;
    private GameObject input;
    private GameObject top;
    private Text score;
    private bool open;
    private AudioSource audio;
    private bool wrongFlag;
    private GameObject timer;
    public int timeMalus = 1;


    void Start ()
    {
        player = GameObject.Find("Player");
        top = transform.GetChild(0).gameObject;
        input = player.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        score = player.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        timer = GameObject.Find("Timer");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && !open)
        {
            input.GetComponent<TextController>().enableInput("Enter 3 digits code ...");
        }
    }

    void OnTriggerExit(Collider other)
    {
        input.GetComponent<TextController>().disableInput();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player")) {
            if (input.GetComponent<InputField>().text == solution && !open)
            {
                input.GetComponent<TextController>().disableInput();
                open = true;
                player.GetComponent<PlayerScript>().keys++;
                score.text = "Keys : " + player.GetComponent<PlayerScript>().keys;
                GetComponent<AudioSource>().Play();
            }
            if (!wrongFlag && input.GetComponent<TextController>().inputSize() == 3)
            {
                wrongFlag = true;
				timer.GetComponent<timerController>().changeTime(timeMalus);
            }
            if (wrongFlag && input.GetComponent<TextController>().inputSize() < 3)
            {
                wrongFlag = false;
            }
        }
    }
    
    void Update()
    {
        if (open)
        {
            if (top.transform.eulerAngles.z >= 300 || top.transform.eulerAngles.z == 0)
                top.transform.eulerAngles -= new Vector3(0, 0, 0.5f);
        }
    }
}
