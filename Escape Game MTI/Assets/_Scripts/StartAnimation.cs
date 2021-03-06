﻿using System.Collections;
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
                door.transform.position += new Vector3(0, -doorSpeed * Time.deltaTime, 0);
                light.intensity -= doorSpeed * Time.deltaTime * 0.3f;
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
                door.transform.position += new Vector3(0, doorSpeed * Time.deltaTime, 0);
                if (light.intensity < 1)
                    light.intensity += doorSpeed * 0.3f * Time.deltaTime;
            }
            else
            {
                audio.Stop();
                light.intensity = 1;
                GetComponent<StartAnimation>().enabled = false;
            }
        }

    }
}
