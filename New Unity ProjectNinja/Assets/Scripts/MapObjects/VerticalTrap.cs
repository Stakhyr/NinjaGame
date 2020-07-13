using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTrap : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rgBody;


    void Start()
    {
        rgBody = gameObject.GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player")) 
        {
            rgBody.isKinematic = false;
            Destroy(gameObject, 2f);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player")) 
        {
            Debug.Log("GameOver");
        }
    }
}
