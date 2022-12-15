using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public float ShieldCoolDown;
    public float AttackRate;
    private GameObject Lvl1Shield;
    public GameObject Shield;
    private GameObject PlayerPos;
    public static bool ShieldOut;

    // Start is called before the first frame update
    void Start() {
        PlayerPos = GameObject.FindWithTag("Player");
        ShieldOut = false;

    }

    // Update is called once per frame
    void Update() {
        ShieldCoolDown += Time.deltaTime;
        Enemy = GameObject.FindWithTag("Enemy");
        if(ShieldCoolDown >= AttackRate) {
            ShieldCoolDown = AttackRate;
        }

    }
    private void FixedUpdate() {

        if(ShieldCoolDown >= AttackRate && !ShieldOut) {
            Attack();
            ShieldCoolDown = 0;
        }


    }

    public void Attack() {
        Lvl1Shield = Instantiate(Shield, PlayerPos.transform.position, Quaternion.identity);
        ShieldOut = true;

    }
}
