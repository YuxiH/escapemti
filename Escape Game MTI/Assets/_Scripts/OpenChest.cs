using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour {

    public string solution;
    public GameObject player;
    public GameObject inp;
    public InputField input;
    public GameObject top;
    public Text score;
    private bool open;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && !open)
        {
            UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController sc = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
            sc.mouseLook.SetCursorLock(false);
            inp.SetActive(true);
            input.placeholder.GetComponent<Text>().text = "Enter 3 digits code ...";
        }
    }

    void OnTriggerExit(Collider other)
    {
        UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController sc = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
        sc.mouseLook.SetCursorLock(true);
        inp.SetActive(false);
        input.text = "";
        input.placeholder.GetComponent<Text>().text = "";
    }

    void OnTriggerStay(Collider other)
    {
        if (input.text == solution && !open)
        {
            UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController sc = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
            sc.mouseLook.SetCursorLock(true);
            open = true;
            player.GetComponent<PlayerScript>().keys++;
            score.text = "Keys : " + player.GetComponent<PlayerScript>().keys;
            inp.SetActive(false);
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
