using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rgBody;
    void Start()
    {
        rgBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player")) 
        {
            Invoke("DroppingPlatform", 1f);
            Destroy(gameObject, 2f);
        }
    }

    void DroppingPlatform() 
    {
        rgBody.isKinematic = false;
    }
}
