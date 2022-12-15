using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerMoverment : MonoBehaviour {
    public float moveSpeed;

    GameObject Enemy;
    GameObject Dagger;
    Rigidbody2D rb;
    public float Damage;
    public GameObject[] Enemies;
    public int RandomNum;
    public GameObject SpawnedBlood;
    public GameObject Blood;
    private AudioSource audioData;




    private void Awake() {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        RandomNum = Random.Range(1, Enemies.Length);
        Enemy = Enemies[RandomNum];
        Dagger = GameObject.Find("ThrowingBlade(Clone)");
        audioData = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start() {
        rb = Dagger.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
       Dagger.transform.Rotate(0, 0, 100 * Time.deltaTime); //rotates 50 degrees per second around z axis 
        if(Enemy == null) {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");

            RandomNum = Random.Range(1, Enemies.Length);

            Enemy = Enemies[RandomNum];
        }
    }

    void FixedUpdate() {
        Vector3 direction = (Enemy.transform.position - Dagger.transform.position).normalized;
        Dagger.transform.position = (Dagger.transform.position + direction * moveSpeed * Time.deltaTime); //moves dagger
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy") {//damage the enemy

            EnemyScript Spawner = other.GetComponent<EnemyScript>();

            if(Spawner != null) {
                Spawner.takeDamage(Damage);
                SpawnedBlood = Instantiate(Blood, other.transform.position, Quaternion.identity);
                SpawnedBlood.transform.parent = other.transform;
                Destroy(SpawnedBlood, 1.7f);
                //Hit Detection
                audioData.Play();
                Destroy(Dagger);
                DaggerThrow.DaggerOut = false;
            }
        }
    }
}
