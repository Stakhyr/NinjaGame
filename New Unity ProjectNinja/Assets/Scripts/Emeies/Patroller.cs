using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    # region Variables Inizialization
    [SerializeField]
    int speed;

    [SerializeField]
    int patrollArea;

    [SerializeField]
    Transform point;

    [SerializeField]
    int stoppingDistance;

    Transform player;
    Animation anim;

    bool movingRight;

    bool angry = false;
    bool chill = false;
    bool goBack = false;

    int currentSpeed;
    int AgressiveSpped = 7;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = gameObject.GetComponent<Animation>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < patrollArea && angry==false) 
        {
            chill = true;
        }

        if(Vector2.Distance(transform.position, player.position) > stoppingDistance) 
        {
            goBack = true;
            angry = false;
        }

        if(Vector2.Distance(transform.position, player.position) < stoppingDistance) 
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true) 
        {
            Angry();
        }
        else if(goBack == true)
        {
            GoBack();
        }
    }

    void Chill() 
    {
        speed = currentSpeed;
        
        if (transform.position.x > point.position.x + patrollArea)
        {
            movingRight = false;
            Flip();
            //anim.Play("Enemy_Walking");
        }
        else if (transform.position.x < point.position.x - patrollArea) 
        {
            movingRight = true;
            Flip();
            //anim.Play("Enemy_Walking");
        }

        if (movingRight) 
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else 
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry() 
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = AgressiveSpped;
    }

    void GoBack() 
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        speed = currentSpeed;

    }
    private void Flip()
    {
       

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
