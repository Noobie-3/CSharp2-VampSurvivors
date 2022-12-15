using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAroundPlayer : MonoBehaviour {

public EnemyScript Spawner;
    public float speed;
    public GameObject ParentOfWeapon;
    public float AttackRate;
    public float Damage;
    private GameObject Player;
    public  GameObject Blood;
    public GameObject SpawnedBlood;
    private AudioSource audioData;


    private void Awake() {
        Player = GameObject.FindWithTag("Player");
        ParentOfWeapon = GameObject.Find("Follower(Clone)");
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        transform.RotateAround(transform.parent.position, new Vector3(0, 0, 1), speed * Time.deltaTime);
        transform.Rotate(0, 0, 50 * Time.deltaTime); //rotates 50 degrees per second around z axis//spins round the player
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy") {//damage the enemy
            EnemyScript Spawner = other.GetComponent<EnemyScript>();

            if(Spawner != null && !Spawner.hitBySpinner) {
                Spawner.takeDamage(Damage);
                Spawner.spinnerCooldown(AttackRate);
                SpawnedBlood = Instantiate(Blood, other.transform.position, Quaternion.identity);
                SpawnedBlood.transform.parent = other.transform;
                Destroy(SpawnedBlood, 1.7f);
                audioData.Play();
            }

        }
    }
}