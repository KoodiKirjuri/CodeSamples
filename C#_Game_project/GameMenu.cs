using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public GameObject theMenu;

    public GameObject[] windows;

    private PlayerHealthManager playerStats;

    public GameObject charStatHolder;

    public Text hpText;

    public Sprite charImage;

    public static GameMenu instance;

    public string MainMenuName;

    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            if (theMenu.activeInHierarchy)
            {
                CloseMenu();
            }
            else
            {
                UpdateMainStats();
                theMenu.SetActive(true);
                GameManager.instance.gameMenuOpen = true;
            }
        }
	}
    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();

        windows[windowNumber].SetActive(!windows[windowNumber].activeInHierarchy);
    }
    public void UpdateMainStats()
    {
        playerStats = PlayerHealthManager.instance;

        hpText.text = "HP: " + playerStats.currentHP + "/" + playerStats.maxHP;
    }
    public void CloseMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
        theMenu.SetActive(false);

        GameManager.instance.gameMenuOpen = false;
    }
    
    public void SaveGame()
    {
        GameManager.instance.SaveDataToJSON();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(MainMenuName);

        //Destroy(AudioManager.instance.gameObject);
    }
}
