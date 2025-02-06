using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincamera : MonoBehaviour {
    Transform target;

    float tLX, tLY, bRX, bRY;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, tLX, bRX),
            Mathf.Clamp(target.position.y, bRY, tLY),
            transform.position.z
            );
    }
    public void SetBound(GameObject map){
        Tiled2Unity.TiledMap config = map.GetComponent<Tiled2Unity.TiledMap>();

        float cameraSize = Camera.main.orthographicSize;

        float aspectRatio = Camera.main.aspect * cameraSize;


        tLX = map.transform.position.x + aspectRatio;
        tLY = map.transform.position.y - cameraSize;

        bRX = map.transform.position.x + config.NumTilesWide - aspectRatio;
        bRY = map.transform.position.y - config.NumTilesHigh + cameraSize;
        //tLX = map.transform.position.x + cameraSize;
        //tLY = map.transform.position.y - cameraSize;
        //bRX = map.transform.position.x + config.NumTilesWide - cameraSize;
        //bRY = map.transform.position.y - config.NumTilesHigh + cameraSize;

        FastMove();
    }
    void FastMove()
    {
        transform.position = new Vector3(
            target.position.x, target.position.y, transform.position.z);
    }
}
