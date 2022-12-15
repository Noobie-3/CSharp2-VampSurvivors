using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject drop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
