using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playedamaged : MonoBehaviour
{
    public Animator A;
    // Start is called before the first frame update
    void Start() {
        A = gameObject.GetComponent<Animator>();
        A.Play("Player Damage");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
