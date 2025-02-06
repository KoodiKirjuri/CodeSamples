using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour {
    public string[] lines;

    private bool canActivate;

    public bool isPerson = false;

    

	void Update () {
		if(canActivate && Input.GetButtonDown("Fire2") && !DialogManager.instance.dialogbox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialog(lines, isPerson);


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
