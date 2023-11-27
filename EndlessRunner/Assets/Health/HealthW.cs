using UnityEngine;
using System.Collections;

public class HealthW : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GameObject phealth = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.health == 2) {
            GetComponent<Renderer>().enabled = false;
        }

    }
}
