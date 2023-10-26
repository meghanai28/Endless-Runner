using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    public float gHeight;
    [SerializeField] private BoxCollider2D box;
    void Awake()
    {
        gHeight = transform.position.x + (GetComponent<Collider>().size.y/2);
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
