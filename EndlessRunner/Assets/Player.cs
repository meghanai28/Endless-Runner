using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float gravity; // gravity that acts on the player
    public Vector2 velocity; // velocity of the player (both horizontal and vertical)

    public float accelerationX = 10;
    public float maxAccX = 10;
    
    public float maxVelocityX = 100;

    public float gHeight = 5; //height of the ground where player jumps from

    public bool onGround = false; // is the player on the ground?

    public float jumpVelocity = 60; // the vertical velocity of the player jump


    public bool holdJump = false; // we want to check if the hold button is being held

    public float maxJmpTime =0.4f; // max 0.4 second hold time

    public float jmpTime = 0.0f;

    public float jmpGroundLeeway = 1; // give player leeway when they are close to the ground because humans cant see perfectly

    public float distance =0; // player distance

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; // position
        float dist = Mathf.Abs(position.y - gHeight); // distance between ground and current position

        if(onGround || dist <= jmpGroundLeeway)
        {
            if(Input.GetKeyDown(KeyCode.Space)) // when player presses the button
            {
                onGround = false;
                velocity.y = jumpVelocity;
                holdJump = true; // button is pressed player is holding space down
                 jmpTime = 0; // once jumped set jmpTime to zero
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)) // space is not pressed
        {
            holdJump = false; // the space is no longer pressed
        }
    }

    // jumps should always be the same
    private void FixedUpdate()
    {
        Vector2 position = transform.position; // position
 
        if(!onGround)
        {
            if(holdJump) // jump being held
            {
                jmpTime += Time.fixedDeltaTime; // add the time
                if(jmpTime >= maxJmpTime)
                {
                    holdJump = false;
                }
            }

            position.y += velocity.y * Time.fixedDeltaTime; // change y position by the velocity y component

            if(!holdJump) // gravity should be applied when the space button is not held
            {
                velocity.y += gravity * Time.fixedDeltaTime; // gravity make the velocity negative so that player can fall
            }


            Vector2 raycastOrigin = new Vector2(position.x + 0.7f, position.y);
            Vector2 raycastDirection = Vector2.up;
            float raycastDistance = velocity.y * Time.fixedDeltaTime;

            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance);


            if(hit.collider != null)
            {
                Ground ground = hit.collider.GetComponent<Ground>();
                
                if(ground != null && raycastDistance <0)
                {
                    gHeight = ground.gHeight;
                    position.y = gHeight;
                    onGround = true;
                }
                else if (ground != null)
                {
                    Destroy(GameObject.Find("Player"));
                }
            }


        }

        distance += velocity.x * Time.fixedDeltaTime; // distance calculation

        if(onGround)
        {
            
            float ratio = velocity.x / maxVelocityX;
            accelerationX = maxAccX * (1-ratio); // from 1 to 0, acceleration declines as player gets faster
            velocity.x += accelerationX * Time.fixedDeltaTime; // change x velocity

            if(velocity.x >= maxVelocityX)
            {
                velocity.x = maxVelocityX;
            }

            Vector2 raycastOrigin = new Vector2(position.x, position.y);
            Vector2 raycastDirection = Vector2.up;
            float raycastDistance = velocity.y * Time.fixedDeltaTime;

            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance);


            if(hit.collider == null)
            {
               onGround = false;
            }
            else
            {
                RaycastHit2D hit2 = Physics2D.Raycast(raycastOrigin, raycastDirection, 8);
                if(hit2.collider != null)
                {
                    Destroy(GameObject.Find("Player"));
                }
            }

        }


       transform.position = position; // change the position of the object after update occurs
    }
}
