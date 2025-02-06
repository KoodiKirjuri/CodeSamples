using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private GameObject Vanhempi;
    public GameObject Replaceable;
    public GameObject Golden;

    public bool gameMenuOpen;

    public bool dialogActive;

    // Use this for initialization
    void Start()
    {
        Vanhempi = GameObject.Find("ActiveWeapon");
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Replaceable = GameObject.Find("ActiveWeapon").transform.GetChild(0).gameObject;
        if (Input.GetButtonDown("Fire3"))
        {
            Destroy(Replaceable);
            Instantiate(Golden, PlayerMovement.instance.transform.position, Quaternion.identity, Vanhempi.transform);
        }
        if (dialogActive || gameMenuOpen)
        {
            PlayerMovement.instance.canMove = false;
        }
        else
        {
            PlayerMovement.instance.canMove = true;
        }
    }
    public void usepotion()
    {
        PlayerHealthManager.instance.maxHP++;
        PlayerHealthManager.instance.currentHP++;
    }
    public void useSpeed()
    {
        PlayerMovement.instance.speed++;
    }
    public void SaveDataToJSON()
    {
        PlayerData playerData = new PlayerData
        {
            PlayerPosition = PlayerHealthManager.instance.transform.position,
            currentHP = PlayerHealthManager.instance.currentHP
        };

        if (PlayerHealthManager.instance.gameObject.activeInHierarchy)
        {
            playerData.playerActive = true;

        }
        else
        {
            playerData.playerActive = false;
        }

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.dataPath + "/playerData.json", json);
    }
    
}
