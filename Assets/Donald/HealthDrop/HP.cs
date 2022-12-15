using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public uint nutritionalValue;
    GameController gc;

    void Start()
    {
        gc = GameObject.FindWithTag("GC").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Script_That_Holds_The_Players_Health
        // Variable_Accessor
        // =
        // player.GetComponent<Script_That_Holds_The_Players_Health>();
        if (other.gameObject.tag == "PlayerHurtbox")
        { gc.heal(nutritionalValue); Destroy(gameObject); }
    }
}
