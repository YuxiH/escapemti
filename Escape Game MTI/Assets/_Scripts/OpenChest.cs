using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour {
    
    public GameObject player;
    public GameObject inp;
    public InputField input;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
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
}
