using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour {
    public GameObject player;
    public GameObject door;
    public GameObject doorEvent;
    private bool start;
    public float doorSpeed;
    public GameObject sunlight;
    private Light light;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

	// Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        start = true;
        light = sunlight.GetComponent<Light>();
    }

    void Update()
    {
        if (start && !doorEvent.GetComponent<DoorScript>().end)
        {
            if (door.transform.position.y > 2.5)
            {
                if (!audio.isPlaying)
                    audio.Play();
                door.transform.position += new Vector3(0, -doorSpeed, 0);
                light.intensity -= doorSpeed * 5;
            }
            else
            {
                audio.Stop();
                light.intensity = 0;
            }
        }
        if (doorEvent.GetComponent<DoorScript>().end)
        {
            if (door.transform.position.y < 6.5)
            {
                if (!audio.isPlaying)
                    audio.Play();
                door.transform.position += new Vector3(0, doorSpeed, 0);
                if (light.intensity < 15)
                    light.intensity += doorSpeed * 5;
            }
            else
            {
                audio.Stop();
                light.intensity = 15;
            }
        }

    }
}
