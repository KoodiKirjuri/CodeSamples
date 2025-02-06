using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    /// <param name="="Collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Healthpotion"))
            {
               GameManager.instance.usepotion();
            }
            if (gameObject.CompareTag("Speedpotion"))
            {
                GameManager.instance.useSpeed();
            }
        }
    }
}
