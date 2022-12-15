using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_behavior : MonoBehaviour
{

    Vector2 direction;
    bool facingLeft = false;
    SpriteRenderer sr;
    public float Damage;
    public float timer;
    public float HighTime;
    public GameObject Sword;
    public GameObject SpawnedBlood;
    public GameObject Blood;
    private AudioSource audioData;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Sword = GameObject.Find("Sword Of Killing Time(Clone)");
        audioData = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if(Spawn_Sword.SwordOut) {
            timer += Time.deltaTime;
        }


    }
    private void FixedUpdate() {
        if(timer >= HighTime) {
            Destroy(Sword);
            timer = 0;
            Spawn_Sword.SwordOut = false;
        }

        if(direction.x < 0 && !facingLeft) {
            facingLeft = true;
        }
        else if(direction.x > 0 && facingLeft) {
            facingLeft = false;
        }

        if(facingLeft) {
            transform.SetPositionAndRotation(transform.parent.position + new Vector3(-1, 0, 0), Quaternion.Euler(180, 0, 134));
        }
        if(!facingLeft) {
            transform.SetPositionAndRotation(transform.parent.position + new Vector3(1, 0, 0), Quaternion.Euler(0,0,315));
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        EnemyScript Spawner = other.GetComponent<EnemyScript>();

        if(Spawner != null) {
            Spawner.takeDamage(Damage);
            SpawnedBlood = Instantiate(Blood, other.transform.position, Quaternion.identity);
            SpawnedBlood.transform.parent = other.transform;
            Destroy(SpawnedBlood, 1.7f);
            audioData.Play();
        }
    }
}
