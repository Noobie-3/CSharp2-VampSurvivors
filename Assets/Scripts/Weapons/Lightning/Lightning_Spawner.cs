using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_Spawner : MonoBehaviour
{

    public GameObject Enemy;
    public float LightningCoolDown;
    public float AttackRate;

    public Vector3 offset;

    public static GameObject TempWeapon;
    public GameObject Lightning;
    private GameObject PlayerPos;
    public static bool LightningOut;
    public GameObject[] Enemies;
    public int RandomNum;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindWithTag("Player");
        offset = new Vector3(.0f,2.7f,0);

    }

    // Update is called once per frame
    void Update() {
        LightningCoolDown += Time.deltaTime;

        if(LightningCoolDown >= AttackRate) {
            LightningCoolDown = AttackRate;
        }

    }

    private void FixedUpdate() {

        if(LightningCoolDown >= AttackRate && !LightningOut) {
            Attack();
            LightningCoolDown = 0;
        }


    }



    public void Attack() {
        
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        RandomNum = Random.Range(1, Enemies.Length);
        Enemy = Enemies[RandomNum];
        TempWeapon = Instantiate(Lightning, Enemy.transform.position + offset, Quaternion.identity);
        LightningOut = true;

    }
}
