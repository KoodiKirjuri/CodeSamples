using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb;

    private Vector2 mov;

    private Animator anim;

    public GameObject initialMap;

    public static PlayerMovement instance;

    public bool canMove;

    public bool isSwordAvaible;
    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;

            canMove = true;

        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Camera.main.GetComponent<Maincamera>().SetBound(initialMap);

    }

    void Update()
    {
        if (canMove)
        {
            Movements();
            Animations();
        }
    }

    void Movements()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (mov.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else if (mov.x > 0)
        {

            transform.localScale = new Vector3(1, 1, 0);
        }

    }

    private void Animations()
    {
        if (canMove && mov != Vector2.zero)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

    }

    private void FixedUpdate()
    {


        rb.MovePosition(rb.position + mov * -speed * -Time.deltaTime);

    }
}