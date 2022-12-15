using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator A;
    // Start is called before the first frame update
    void Start() {
        A = gameObject.GetComponent<Animator>();
        A.Play("Die");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
