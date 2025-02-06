using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damageToGive;
    public bool canbehurt;
    public float timer = 2;
    public bool InArea;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0)
        {
            if (timer >= 0.54f && timer <= 1f)
            {
                canbehurt = true;
            }
            if(timer >= 1.46f && timer < 2)
            {
                canbehurt = false;
            }
            else if(timer >= 2)
            {
                timer = 0;
            }
            if(InArea == true && timer >= 0.54f && timer <= 1f)
            {
                GameObject.Find("Player").GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerSpike") && canbehurt == true)
        {
            GameObject.Find("Player").GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            canbehurt = false;
            InArea = true;
        }
        else if (collision.CompareTag("PlayerSpike"))
        {
            InArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        InArea = false;
    }
}

// Update is called once per frame