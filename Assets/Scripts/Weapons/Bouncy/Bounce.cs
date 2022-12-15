using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Shield;
    public float speed;
    public bool BouceBack = false;
    Rigidbody2D ShotBody;
    private GameObject PlayerPos;
    GameObject TempShield;
    public GameObject ShieldPrefab;
    public float Damage;
    public GameObject[] Enemies;
    public int RandomNum;
    public int BounceCount;
    public GameObject SpawnedBlood;
    public GameObject Blood;
    private AudioSource audioData;


    public bool ShieldOut;
    // Start is called before the first frame update
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        RandomNum = Random.Range(1, Enemies.Length);
        Enemy = Enemies[RandomNum];

        PlayerPos = GameObject.FindWithTag("Player");

        Shield = GameObject.Find("Shield(Clone)");
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if(Enemy ==  null) {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");

            RandomNum = Random.Range(1, Enemies.Length);//makes sure no buggy things happens

            Enemy = Enemies[RandomNum];
        }
    }

    private void FixedUpdate() {
        if(BouceBack == true) {
            Vector3 direction = (PlayerPos.transform.position - Shield.transform.position).normalized;
            Shield.transform.position += direction * speed * Time.deltaTime;
        }
        else if(BouceBack == false && BounceCount > 0) {
            if(Enemy != null) {
                Vector3 direction = (Enemy.transform.position - Shield.transform.position).normalized;
                Shield.transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" && BounceCount > 0) {
            EnemyScript Spawner = other.GetComponent<EnemyScript>();

            if(Spawner != null) {
                Spawner.takeDamage(Damage);
                SpawnedBlood = Instantiate(Blood, other.transform.position, Quaternion.identity);
                SpawnedBlood.transform.parent = other.transform;
                Destroy(SpawnedBlood, 1.7f);
                audioData.Play();
                RandomNum = Random.Range(1, Enemies.Length);
                Enemy = Enemies[RandomNum];
                BounceCount -= 1;
                if(BounceCount <= 0) {
                    BouceBack = true;
                }
            }
        }

        if(other.gameObject.tag == "PlayerHurtbox" && BouceBack == true) {
            Destroy(Shield);
            BouceBack = false;
            Shield_Spawner.ShieldOut = false;
        }
    }
}
