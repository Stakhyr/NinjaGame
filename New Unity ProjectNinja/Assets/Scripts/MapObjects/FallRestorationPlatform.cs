using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class FallRestorationPlatform : MonoBehaviour
{
    Rigidbody2D rgBody;
    Vector2 currentPostion;
    bool movingBack;
    void Start()
    {
        rgBody = gameObject.GetComponent<Rigidbody2D>();

        // fix initial position of platform
        currentPostion = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && movingBack==false)
        {
            Invoke("DroppingPlatform", 1f);
        }
    }

    void DroppingPlatform()
    {
        rgBody.isKinematic = false;
        Invoke("BackPlatform", 1f);
    }

    void BackPlatform() 
    {
        rgBody.velocity = Vector2.zero;
        rgBody.isKinematic = true;
        movingBack = true;
    }


    private void Update()
    {
        if(movingBack == true) 
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPostion, 20f * Time.deltaTime);
        }

        if(transform.position.y == currentPostion.y) 
        {
            movingBack = false;
        }
    }
}
