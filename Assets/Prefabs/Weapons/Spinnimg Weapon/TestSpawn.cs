using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestSpawn : MonoBehaviour {
    public int numberOfProjectiles;

    public GameObject projectile;

    public Vector2 startPoint;
    public GameObject player;
    public float radius;
    public GameObject FollowerPreFab;
    public bool FollowerOut;
    public GameObject Follower;
    public int WeaponLevel;
    public float MoveSpeed;
    public GameObject[] AllSpinners;


    GameObject ToDestroy;
    public GameObject LevelOne;
    public GameObject LevelTwo;
    public GameObject LevelThree;
    public GameObject LevelFour;
    public GameObject LevelFive;
    public GameObject LevelSix;
    public GameObject LevelSeven;
    public GameObject LevelMax;
    private bool LevelOneOut;
    private bool LevelTwoOut;
    private bool LevelThreeOut;
    private bool LevelFourOut;
    private bool LevelFiveOut;
    private bool LevelSixOut;
    private bool LevelSevenOut;
    private bool LevelMaxOut;

    // Use this for initialization
    void Start() {
        player = GameObject.FindWithTag("Player");
        MoveSpeed = 100;
    }

    // Update is called once per frame
    void Update() {
        if(!FollowerOut) {

        }

        if(WeaponLevel == 1 & !LevelOneOut) {
            SpawnFollower();
            startPoint = player.transform.position;
            numberOfProjectiles = 1;
            SpawnProjectiles(numberOfProjectiles);
            SetSpeed();

            LevelOneOut = true;
        }

        if(WeaponLevel == 2 & !LevelTwoOut) {//level 2

            killWeapon();
            SpawnFollower();
            numberOfProjectiles++;
            SpawnProjectiles(numberOfProjectiles);
            SetSpeed();
            LevelTwoOut = true;
        }



        if(WeaponLevel == 3 & !LevelThreeOut) {
            killWeapon();
            radius += radius * .25f;
            SpawnFollower();
            SpawnProjectiles(numberOfProjectiles);
            MoveSpeed += MoveSpeed * .30f;
            SetSpeed();
            LevelThreeOut = true;
        }


            if(WeaponLevel == 4 &! LevelFourOut) {

            //make last longer
            
            LevelFourOut = true;


            //will spawn the Next variation of the weapon

        }
        if(WeaponLevel == 5 &! LevelFiveOut) {
            killWeapon();
            SpawnFollower();
            numberOfProjectiles++;
            SpawnProjectiles(numberOfProjectiles);
            SetSpeed();
            LevelFiveOut = true;

            //will spawn the Next variation of the weapon
        }

        if(WeaponLevel == 6 & !LevelSixOut) {
            killWeapon();
            SpawnFollower();
            MoveSpeed += MoveSpeed * .30f;
            radius += radius * .25f;
            SpawnProjectiles(numberOfProjectiles);
            SetSpeed();
            LevelSixOut = true;

            //will spawn the Next variation of the weapon

        }

        if(WeaponLevel == 7 &! LevelSevenOut) {

            SetSpeed();
            LevelSevenOut = true;

            //will spawn the Next variation of the weapon

        }

        if(WeaponLevel == 8 & !LevelMaxOut) {
            killWeapon();
            SpawnFollower();
            numberOfProjectiles++;
            SpawnProjectiles(numberOfProjectiles);
            SetSpeed();
            LevelMaxOut = true;



        }



        void SpawnProjectiles(int numberOfProjectiles) {
            float angleStep = 360f / numberOfProjectiles;
            float angle = 0f;

            for(int i = 0; i <= numberOfProjectiles - 1; i++) {
                startPoint = player.transform.position;
                float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);

                GameObject proj = Instantiate(projectile, projectileVector, Quaternion.identity);
                SpinAroundPlayer ProjSpeed = proj.GetComponent<SpinAroundPlayer>();
                proj.transform.parent = Follower.transform;
                angle += angleStep;
                
            }



        }

        void killWeapon() {
            FollowerOut = false;
            Destroy(Follower);
        
        }

        void SpawnFollower() {
            Follower = Instantiate(FollowerPreFab, player.transform.position, Quaternion.identity);
            FollowerOut = true;
        }

        void SetSpeed() {
            Transform[] allChildren = Follower.transform.GetComponentsInChildren<Transform>();
            for(int i = 0; i < allChildren.Length; i++) {
                if(allChildren[i].name == "TestSpinner(Clone)") {
                    allChildren[i].gameObject.GetComponent<SpinAroundPlayer>().speed = MoveSpeed;
                }
            }
        }
    }
}

