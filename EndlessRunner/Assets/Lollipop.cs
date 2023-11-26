using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lollipop : MonoBehaviour
{
    public float eHeight;
    private void Awake()
    {
        eHeight = transform.position.y + ((transform.localScale.y));
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
