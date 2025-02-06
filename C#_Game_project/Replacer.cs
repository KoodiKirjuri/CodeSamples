using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour
{
    private GameObject Vanhempi;
    public GameObject Replazer;
    public GameObject Replaceable;
    public int childs;

    // Update is called once per frame
    private void Start()
    {
        Vanhempi = GameObject.Find("ActiveWeapon");
    }
    void Update()
    {
        Replaceable = GameObject.Find("ActiveWeapon").transform.GetChild(0).gameObject;
    }
    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            childs = gameObject.transform.childCount;
            for(int i=0; i<childs; i++)
            {
                Destroy(Replaceable);
            }
            Instantiate(Replazer, transform.position, Quaternion.identity, Vanhempi.transform);
            collider.enabled = false;
            yield return new WaitForSeconds(0.5f);
            collider.enabled = true;
        }
    }
        
}
