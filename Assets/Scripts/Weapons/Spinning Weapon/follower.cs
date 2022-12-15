using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    public float moveSpeed;
    PlayerScript SimpMove;
    private GameObject PlayerPos;
    public Transform follow;


    private void Awake() {
        PlayerPos = GameObject.FindWithTag("Player");
        follow = transform;
    }

    private void Start() {
    }

    private void Update() {
        follow.position = PlayerPos.transform.position; // tracks player
    }

    private void FixedUpdate() {


    }

}
