using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterControllerMove : MonoBehaviour
{
    //public float speed = 10f;

    #region Variables Inizialization

    bool isFacingRight = true;

     LayerMask whatIsGround;

    bool isAtacking = false;

    //inizialization of our gameObject
    new Rigidbody2D rigidbody;

    // show which animation, we will use
    Animator animatation;

    SpriteRenderer sprite;

    [SerializeField]
    int speed;
    [SerializeField]
    int jumpForce;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    GameObject AtackHitBox; 

    bool isOnGround;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // realization of all our components
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animatation = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        AtackHitBox.SetActive(false);

       

    }

    private void FixedUpdate()
    {
        CheckGround();
        
        //moving right
        HorizontalMovement();

        Jump();
       
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAtacking)
        {
            isAtacking = true;
            //int choose = UnityEngine.Random.Range(1, 5);
            //animatation.Play("Player_Atack" + choose);
            animatation.Play("Player_Atack1");
            StartCoroutine(DoAtack());
        }
    }

    IEnumerator DoAtack() 
    {
        AtackHitBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        AtackHitBox.SetActive(false);

        isAtacking = false;

    }

    //Сharacter behavior in collision with moving platforms
   

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void HorizontalMovement() 
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            if (isOnGround && !isAtacking && !isFacingRight)
            {
                animatation.Play("Player_Run");
                Flip();
            }


        }

        //moving left
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            if (isOnGround && !isAtacking && isFacingRight)
            {
                animatation.Play("Player_Run");
                Flip();

            }
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            if (isOnGround == true)
            {
                if (!isAtacking)
                {
                    animatation.Play("Player_Simple_State");
                }
            }
        }
    }

    void CheckGround() 
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;

        }
    }

    void Jump() 
    {
        if (Input.GetKey(KeyCode.W) && isOnGround == true)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            if (isAtacking == false)
            {
                animatation.Play("Player_Jump");
                isOnGround = false;

                if (Input.GetKey(KeyCode.D) && !isFacingRight)
                {
                    Flip();
                }

                else if (Input.GetKey(KeyCode.A) && isFacingRight)
                {
                    Flip();
                }


            }
        }
    }


    #region Colision with Platforms
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // instead of name, try to use tag
        if (collision.gameObject.name.Equals("HorizontalMovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.name.Equals("HorizontalMovingPlatform"))
        {
            this.transform.parent = null;
        }
    }
    #endregion
}
