using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class DestroyObject : MonoBehaviour
{
    
    bool isShacking = false;
    float shake = 0.1f;
    Vector2 pos;

    [SerializeField]
    int health = 2;

    //which objectc will appear after box destroy
    [SerializeField]
    Object destructable;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isShacking == true) 
        {
            //read!!
            transform.position = pos + UnityEngine.Random.insideUnitCircle * shake;
        }
        
    }


    
    // discrabe some action, when triger is active
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon")) 
        {
            isShacking = true;
            health --;
            

            if (health <= 0) 
            {
                ExplodeTheObject();
            }
            Invoke("StopShaking", 0.5f);
        }
    }

    private void ExplodeTheObject()
    {
        GameObject destruct = (GameObject)Instantiate(destructable);
        destruct.transform.position = transform.position;

        Destroy(gameObject);
    }

    void StopShaking() 
    {
        isShacking = false;
        transform.position = pos;
    }
}
