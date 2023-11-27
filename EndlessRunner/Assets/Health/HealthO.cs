using UnityEngine;
using System.Collections;

public class HealthO : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.health == 1)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}
