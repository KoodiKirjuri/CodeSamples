using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float speed;

    GameObject player;
    Rigidbody2D rb2d;
    Vector3 target, dir;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        //AudioManager.instance.Play("EnemyShoot");

        if (player != null)
        {
            target = player.transform.position;
            dir = (target - transform.position).normalized;
        }
    }
    private void Update()
    {

    }
    void FixedUpdate()
    {
        if (target != Vector3.zero)
        {

            rb2d.MovePosition(transform.position + dir * speed * Time.fixedDeltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player" || col.transform.tag == "Attack" || col.transform.tag == "Wall")
        {
            Destroy(gameObject);

        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
