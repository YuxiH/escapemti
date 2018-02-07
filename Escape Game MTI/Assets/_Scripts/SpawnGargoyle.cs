using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGargoyle : MonoBehaviour {
    public GameObject gargoyle;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            gargoyle.SetActive(true);
            audio.Play();
        }
    }
}
