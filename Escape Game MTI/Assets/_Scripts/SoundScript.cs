using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
