using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instakill : MonoBehaviour
{
    public float damageToTake;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GSword"))
        {
            transform.GetComponent<EnenemyHealthManager>().HurtEnemy(damageToTake);
        }
    }
}
