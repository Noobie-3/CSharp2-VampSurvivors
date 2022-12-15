using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    GameObject mapHandler;

    void OnTriggerEnter2D(Collider2D other)
    {
        mapHandler.GetComponent<MapHandler>().HandleMapTiling(gameObject);
    }
}
