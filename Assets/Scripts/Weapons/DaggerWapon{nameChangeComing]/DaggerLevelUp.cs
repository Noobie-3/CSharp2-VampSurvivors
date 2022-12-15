using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerLevelUp : MonoBehaviour
{
    private GameObject Lvl1Dag;
    private GameObject Lvl2Dag;
    private GameObject Lvl3Dag;
    private GameObject Lvl4Dag;
    private GameObject Lvl5Dag;
    private GameObject Lvl6Dag;
    private GameObject Lvl7Dag;
    private GameObject Lvl8Dag;
    private GameObject EvoDag;
    Vector3 offset;


    private GameObject PlayerPos;
    public float DaggerCoolDown;
    public float AttackRate;



    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        DaggerCoolDown += Time.deltaTime;
        if(DaggerCoolDown >= AttackRate) {
            DaggerCoolDown = AttackRate;
        }
    }

    public void Attack() {
        //Lvl1Dag = Instantiate(Level1Dag, PlayerPos.transform.position + offset, Quaternion.identity); // get second opinion on implementation before going ahead
       // DaggerOut = true;

    }
}
