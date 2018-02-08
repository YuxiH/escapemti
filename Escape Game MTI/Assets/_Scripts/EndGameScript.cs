using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EndGameScript : MonoBehaviour {
    private GameObject player;
    private bool start;
    public GameObject gargoyle;
    private bool shutdown = false;
    public float remainingTime;
    private GameObject door;
    public float doorSpeed;
    private AudioSource audio;
    private GameObject sunlight;

	void Start () {
        player = GameObject.Find("Player");
        door = GameObject.Find("Door");
        audio = GetComponent<AudioSource>();
        sunlight = GameObject.Find("Sunlight");
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            start = true;
            player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
            gargoyle.SetActive(true);
        }
    }

    void Update()
    {
        if (start && !shutdown)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            if (player.transform.eulerAngles.y < 355)
                player.transform.eulerAngles -= new Vector3(0, 1, 0);
            else
            {
                remainingTime -= Time.deltaTime;
                if (remainingTime < 0)
                {
                    shutdown = true;
                }
            }
        }
        if (shutdown)
        {
            if (door.transform.position.y > 2.5)
                door.transform.position += new Vector3(0, -doorSpeed, 0);
            else
            {
                sunlight.GetComponent<Light>().intensity = 0;
                GetComponent<EndGameScript>().enabled = false;
            }
        }
    }
}
