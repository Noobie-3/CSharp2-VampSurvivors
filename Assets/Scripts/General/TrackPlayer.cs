using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    public float moveSpeed;

    GameObject player;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Flip sprite horizontally based on direction
        if (direction.x < 0)
        {
            sr.flipX = true;
        }
        else if (sr.flipX)
        {
            sr.flipX = false;
        }

        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }
}
