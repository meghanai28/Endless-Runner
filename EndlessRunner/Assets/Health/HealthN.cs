using UnityEngine;
using System.Collections;

public class HealthN : MonoBehaviour
{
    // Use this for initialization
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.health == 0)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}
