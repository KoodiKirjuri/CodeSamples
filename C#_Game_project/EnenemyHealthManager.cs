using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnenemyHealthManager : MonoBehaviour {
    public Image content;
    public float EnemyMaxHealth;
    public float EnemyCurrentHealth;
    public static EnenemyHealthManager instance;

    void Start()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
        instance = this;
    }

    void Update()
    {
        content.fillAmount = EnemyCurrentHealth / 100;

        if(content.fillAmount <= 0)
        {
            //AudioManager.instance.Play("EnemyDie");

            
            Destroy(gameObject);
        }
        if(EnemyCurrentHealth < EnemyMaxHealth)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void HurtEnemy(float damageToTake)
    {
        //AudioManager.instance.Play("PlayerHit");
        EnemyCurrentHealth -= damageToTake;
    }

    public void SetMaxHealth()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GSword"))
        {
            Destroy(gameObject);
        }
    }
}
