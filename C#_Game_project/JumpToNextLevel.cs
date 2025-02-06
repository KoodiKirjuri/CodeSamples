using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class JumpToNextLevel : MonoBehaviour {
    public static JumpToNextLevel instance;
    private bool canActivate;
    public string newGameScene;
    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (canActivate && Input.GetButtonDown("Fire2") && !DialogManager.instance.dialogbox.activeInHierarchy)
        {
            NextLevel();

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

    public void NextLevel()
    {
        SceneManager.LoadScene(newGameScene);
    }

}