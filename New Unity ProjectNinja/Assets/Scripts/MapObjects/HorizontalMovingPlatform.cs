using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class HorizontalMovingPlatform : MonoBehaviour
{
    // indicates which axis to move
    float dirX;
    //speed of platform
    float speed = 3f;

    // set direction of the moving
    bool movingRight = true;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 4f) 
        {
            movingRight = false;
        }
        else if (transform.position.x < -4f) 
        {
            movingRight = true;
        }

        if (movingRight) 
        {
            // movement of our platform
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else 
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
