using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {
    public float damageToTake;
    public bool canbehurt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword") && canbehurt == true)
        {
            transform.GetComponent<EnenemyHealthManager>().HurtEnemy(damageToTake);
            canbehurt = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword") && canbehurt == false)
        {
            canbehurt = true;
        }
    }
}


/*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }*/