using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

    public float visionRadius;
    public float speed;

    private GameObject Player;

    private Vector3 initialPosition, target;

    private Rigidbody2D rb2d;

    private Animator anim;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;

        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movements();
        target = initialPosition;

        Vector3 forward = transform.TransformDirection(Player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, forward, visionRadius, 1 << LayerMask.NameToLayer("Player"));

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = Player.transform.position;
                anim.SetBool("Walking", true);
            }
        }

        float distance = Vector3.Distance(target, transform.position);

        Vector3 dir = (target - transform.position).normalized;

      
        rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);

        if (target == initialPosition)
        {
            initialPosition = transform.position;
            anim.SetBool("Walking", false);
        }
        Debug.DrawLine(transform.position, target, Color.green);
    }
    void Movements()
    {
        /*tietokonetta liikuttava asia on positiivinen silloin suorita koodi*/
        if (transform.position.x >= Player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (transform.position.x < Player.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);

        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
/*
public float visionRadius;
public float attackRadius;
public float speed;

private GameObject Player;

private Vector3 initialPosition, target;

private Rigidbody2D rb2d;

public GameObject Bullet;
public float timeToWait = 2f;
bool Attacking;

void Start()
{
    Player = GameObject.FindGameObjectWithTag("Player");

    initialPosition = transform.position;

    rb2d = GetComponent<Rigidbody2D>();
}

void Update()
{
    target = initialPosition;

    Vector3 forward = transform.TransformDirection(Player.transform.position - transform.position);
    Debug.DrawRay(transform.position, forward, Color.red);

    RaycastHit2D hit = Physics2D.Raycast(transform.position, forward, visionRadius, 1 << LayerMask.NameToLayer("Default"));

    if (hit.collider != null)
    {
        if (hit.collider.tag == "Player")
        {
            target = Player.transform.position;
        }
    }

    float distance = Vector3.Distance(target, transform.position);

    Vector3 dir = (target - transform.position).normalized;

    if (target != initialPosition && distance < attackRadius)
    {
        if (!Attacking)
        {

            StartCoroutine(Attack(timeToWait));
        }
    }
    else
    {
        rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
    }
    if (target == initialPosition && distance < 0.05f)
    {
        transform.position = initialPosition;
    }
    Debug.DrawLine(transform.position, target, Color.green);
}

void OnDrawGizmosSelected()
{
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, visionRadius);
    Gizmos.DrawWireSphere(transform.position, attackRadius);
}
IEnumerator Attack(float seconds)
{
    Attacking = true;
    if (target != initialPosition && Bullet != null)
    {

        Instantiate(Bullet, transform.position, transform.rotation);

        yield return new WaitForSeconds(seconds);
    }
    Attacking = false;
}*/