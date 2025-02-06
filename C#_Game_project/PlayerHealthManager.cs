using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {
    public static PlayerHealthManager instance;

    public float currentHP;
    public float maxHP = 4;

    public GameObject target;

    void Start()
    {
        instance = this;

        currentHP = maxHP;
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            DialogManager.instance.StopDialog();

            SceneManager.LoadScene("Inforoom");
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        //AudioManager.instance.Play("EnemyHit");
        currentHP -= damageToGive;
    }

    public void AddPlayerHealth(int healthAmmount)
    {
        currentHP += healthAmmount;
        if(currentHP > maxHP)
        {
            SetMaxHealth();
        }
    }

    public void SetMaxHealth()
    {
        currentHP = maxHP;
    }
}
