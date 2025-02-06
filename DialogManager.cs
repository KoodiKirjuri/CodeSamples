using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text dialogText;
    public GameObject dialogbox;

    private string[] dialogLines;
    private int currentLine = 0;
    private bool justStarted;

    public static DialogManager instance;
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(dialogLines == null)
        {
            return;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (!justStarted)
            {
                currentLine++;
                if(currentLine >= dialogLines.Length)
                {
                    dialogbox.SetActive(false);

                    GameManager.instance.dialogActive = false;
                }
                else
                {
                    dialogText.text = dialogLines[currentLine];
                }
            }
            else
            {
                justStarted = false;
            }
        }
	}
    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;

        currentLine = 0;

        dialogText.text = dialogLines[currentLine];

        dialogbox.SetActive(true);

        GameManager.instance.dialogActive = true;
    }
    public void StopDialog()
    {
        dialogbox.SetActive(false);

        GameManager.instance.dialogActive = false;
    }
}
