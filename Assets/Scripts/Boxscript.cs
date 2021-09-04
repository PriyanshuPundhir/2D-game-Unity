﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxscript : MonoBehaviour
{
    private float min_X = -2.2f, max_X = 2.2f;
    private bool canMove;
    private float move_Speed = 2f;
    private Rigidbody2D myBody;
    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;
   

     void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
    }
    void Start()
    {
        canMove = true;
        if(Random.Range(0, 2) > 0)
        {
            move_Speed *= -1f;
        }
        Gameplaycontroller.instance.currentBox = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
        
    }
    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;
            if(temp.x > max_X)
            {
                move_Speed *= -1f;
            }else if(temp.x < min_X)
            {
                move_Speed *= -1f;
            }
            transform.position = temp;
        }
    }
    public void Dropbox()
    {
        canMove = false;
        myBody.gravityScale = Random.Range(2, 4);
    }
    void Landed()
    {
        if (gameOver)
            return;
        ignoreCollision = true;
        ignoreTrigger = true;
        Gameplaycontroller.instance.SpawnNewBox();
        Gameplaycontroller.instance.MoveCamera();

    }
    void RestartGame()
    {
        Gameplaycontroller.instance.RestartGame();
    }
     void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision)
            return;
        if(target.gameObject.tag == "platform")
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
        }
        if (target.gameObject.tag == "box")
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
        }
        
    }
    void OnTriggerEnter2D(Collider2D target)
    { 
        if (ignoreTrigger)
            return;
        if (target.tag == "game over")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;

            Invoke("RestartGame", 1f);
        }

    } 


}










