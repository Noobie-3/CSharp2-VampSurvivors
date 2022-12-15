using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool godMode;
    public float moveSpeed;
    Vector2 direction;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator a;
    bool facingLeft = false;
    GameController gc;
    public GameObject SpawnedBlood;
    public GameObject Blood;
    private AudioSource audioData;
    int damageDisplayTimer = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        a = GetComponent<Animator>();
        gc = GameObject.FindWithTag("GC").GetComponent<GameController>();
        audioData = GetComponent<AudioSource>();

    }

    private void Update()
    {
        moveSpeed = gc.moveSpeed;
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        // Flip sprite horizontally based on direction
        if (direction.x < 0 && !facingLeft)
        {
            facingLeft = true;
        }
        else if (direction.x > 0 && facingLeft)
        {
            facingLeft = false;
        }
        if (sr.flipX != facingLeft) sr.flipX = facingLeft;

        // Running animation
        if ((direction.x != 0 || direction.y != 0) && !a.GetBool("isRunning")) a.SetBool("isRunning", true);
        else if (direction.x == 0 && direction.y == 0 && a.GetBool("isRunning")) a.SetBool("isRunning", false);

        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

        if(damageDisplayTimer > 0)
        {
            if(--damageDisplayTimer == 0)
            {
                sr.color = new Color(255, 255, 255);
            }
        }
    }

    // Runs every 0.02 seconds
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Hitbox" && other.gameObject.tag == "Enemy")
        {
            EnemyScript es = other.GetComponentInParent<EnemyScript>();

            // Take damage from enemy
            if(es.canAttack() && !godMode)
            {
                es.triggerCooldown();
                SpawnedBlood = Instantiate(Blood, transform.position, Quaternion.identity);
                audioData.Play();
                SpawnedBlood.transform.parent = transform;
                Destroy(SpawnedBlood, 1.8f);
                gc.takeDamage(es.damage);
                sr.color = new Color(255, 0, 0);
                damageDisplayTimer = 12;
            }
        }
    }
}
