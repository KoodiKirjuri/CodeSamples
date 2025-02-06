using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleDialogs : MonoBehaviour
{
    public DialogActivator ascript;
    public NextDialog bscript;
    // Start is called before the first frame update
    void Start()
    {
        ascript = GetComponent<DialogActivator>();
        bscript = GetComponent<NextDialog>();
        ascript.enabled = true;
        bscript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Waterfountain.uses>0)
        {
            ascript.enabled = true;
            bscript.enabled = false;
        }
        else if (Waterfountain.uses <= 0)
        {
            ascript.enabled = false;
            bscript.enabled = true;
        }
        else
        {
            ascript.enabled = false;
            bscript.enabled = true;
        }
    }
}
