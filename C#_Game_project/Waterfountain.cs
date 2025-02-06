using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfountain : MonoBehaviour {
    private bool canActivate;
    public static decimal uses=2;
    public static Waterfountain instance;

    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        
        if (canActivate && Input.GetButtonDown("Fire2"))
        {
            if (PlayerHealthManager.instance.currentHP < PlayerHealthManager.instance.maxHP && uses > 0)
            {
                PlayerHealthManager.instance.SetMaxHealth();
                uses--;
            }
            else if (uses<=0)
            {
                return;
            }
            else
            {
                return;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivate = false;

        }
    }

}