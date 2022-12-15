using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInnerFunction : MonoBehaviour
{
    ChestFunction script;

    void Awake()
    {
        script = transform.parent.GetComponent<ChestFunction>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") script.killNextFrame = true;
    }
}
