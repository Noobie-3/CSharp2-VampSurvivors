using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_Script : MonoBehaviour
{
    public float Damage;
    GameObject LightningRod;
    GameObject Enemy;
    public float EffectLength;
    public GameObject[] Enemies;
    public int RandomNum;
    public GameObject SpawnedBlood;
    public GameObject Blood;
    private AudioSource audioData;


    private void Awake() {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        RandomNum = Random.Range(1, Enemies.Length);
        audioData = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        LightningRod = GameObject.Find("Lightning_Strike(Clone)");

    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy == null) {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");

            RandomNum = Random.Range(1, Enemies.Length);//makes sure no buggy things happens

            Enemy = Enemies[RandomNum];

        }
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Enemy") {//damage the enemy

            EnemyScript Spawner = other.GetComponent<EnemyScript>();

            if(Spawner != null) {
                Spawner.takeDamage(Damage);
                SpawnedBlood = Instantiate(Blood, other.transform.position, Quaternion.identity);
                SpawnedBlood.transform.parent = other.transform;
                Destroy(SpawnedBlood, 1.7f);
                audioData.Play();
                if(Spawner.HP <= 0) {

                    Spawner.death();
                }
                Destroy(Lightning_Spawner.TempWeapon, EffectLength); 
                Lightning_Spawner.LightningOut = false;

            }

        }

    }

}
