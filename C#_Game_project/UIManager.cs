using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Slider playerhealthBar;

    public Text HPText;

    private PlayerHealthManager PlayerHealth;

    void Update()
    {
        PlayerHealth = PlayerHealthManager.instance;

        playerhealthBar.maxValue = PlayerHealth.maxHP;

        playerhealthBar.value = PlayerHealth.currentHP;

        HPText.text = "HP: " + PlayerHealth.currentHP + "/" + PlayerHealth.maxHP;
    }
}
