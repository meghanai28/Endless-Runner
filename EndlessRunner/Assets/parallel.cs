using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallel : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float divide; // how much speed we want floating isles to be
    Player player;


    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float isleV = player.velocity.x / divide;
        Vector2 curPos = transform.position; // get current position

        curPos.x -= 2*(isleV * Time.fixedDeltaTime);

        if(curPos.x < -40)
        {
            curPos.x = 36;
        }

        transform.position = curPos; // after
    }
}
