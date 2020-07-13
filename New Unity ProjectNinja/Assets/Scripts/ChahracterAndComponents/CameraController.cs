using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    public float dumping = 1.5f;
    Vector2 offset = new Vector2(2f,1f);

    bool isLeft;
    private Transform player;
    private int lastX;


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(Math.Abs(offset.x), Math.Abs(offset.y));
        FindPlayer(isLeft);
        
    }
    public void FindPlayer(bool playerIsLeft) 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);

        if (playerIsLeft) 
        {
                                    // what's Vector3?
            transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
        }
        else 
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player) 
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;

            if (isLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);

            }
            else 
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
        
    }
}
