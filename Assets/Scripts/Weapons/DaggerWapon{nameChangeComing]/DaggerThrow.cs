using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerThrow : MonoBehaviour {

    public GameObject Enemy;
    public float DaggerCoolDown;
    public float AttackRate;
    private GameObject Lvl1Dag;
    public GameObject Dagger;
    private GameObject PlayerPos;
    public static bool DaggerOut;
    Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        PlayerPos = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update() {
        DaggerCoolDown += Time.deltaTime;
        Enemy = GameObject.FindWithTag("Enemy");
        if(DaggerCoolDown >= AttackRate) {
            DaggerCoolDown = AttackRate;
        }

    }
    private void FixedUpdate() {

        if(DaggerCoolDown >= AttackRate && !DaggerOut) {
            Attack();
            DaggerCoolDown = 0;
        }


    }

    public void Attack() {
        Lvl1Dag = Instantiate(Dagger, PlayerPos.transform.position + offset, Quaternion.identity);   
        DaggerOut = true;

    }
}

