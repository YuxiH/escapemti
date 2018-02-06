using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGargoyle : MonoBehaviour {
    public GameObject gargoyle;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            gargoyle.SetActive(true);
        }
    }
}
