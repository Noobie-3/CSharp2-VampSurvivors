using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Sword : MonoBehaviour { 

    public GameObject Enemy;    
    public float SwordCoolDown;
    public float AttackRate;
    private GameObject SwordLeft;
    private GameObject SwordRight;
    public GameObject Sword;
    private GameObject PlayerPos;
    public static bool SwordOut;
    Vector3 offset; 
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update() {
        if(!SwordOut) {
            SwordCoolDown += Time.deltaTime;
        }
   //     Enemy = GameObject.FindWithTag("Enemy");
        if(SwordCoolDown >= AttackRate) {
            SwordCoolDown = AttackRate;
        }

    }


        private void FixedUpdate() {

            if(SwordCoolDown >= AttackRate && !SwordOut) {
                Attack();
                SwordCoolDown = 0;
            }


        }

        public void Attack() {
            SwordLeft = Instantiate(Sword, PlayerPos.transform.position + offset, Quaternion.identity);
            SwordOut = true;

        }
    }
