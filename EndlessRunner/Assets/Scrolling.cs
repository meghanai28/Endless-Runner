using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
  
    float depth = 300;
    [SerializeField] private RawImage img;
    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); // intialize basically
    }

    // Update is called once per frame
    void Update()
    {
        float playerVelocity = player.velocity.x/depth;
        img.uvRect = new Rect(img.uvRect.position + new Vector2(playerVelocity,0) * Time.deltaTime,img.uvRect.size);
    }
}
