using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float HP;
    public uint damage;
    public GameObject chest;
    public uint chestChancePercent;
    public bool hitBySpinner = false;
    int timer = 0;
    bool hasAttack = true;
    int damageDisplayTimer = 0;
    bool isDead = false;
    float spinnerCounter = 0;
    GameController gc;
    SpriteRenderer sr;
    public GameObject SpawnedBlood;
    public GameObject Blood;

    void Start()
    {
        gc = GameObject.FindWithTag("GC").GetComponent<GameController>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(spinnerCounter > 0)
        {
            spinnerCounter -= Time.deltaTime;
            if(spinnerCounter <= 0)
            {
                spinnerCounter = 0;
                hitBySpinner = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (!hasAttack)
        {
            // 50 = 1 second
            if (timer++ >= 32)
            {
                timer = 0;
                hasAttack = true;
            }
        }

        if(damageDisplayTimer > 0)
        {
            if(--damageDisplayTimer == 0)
            {
                if(isDead) death();
                else sr.color = new Color(255, 255, 255);
            }
        }
    }

    public void triggerCooldown()
    {
        hasAttack = false;
    }

    public bool canAttack()
    {
        return hasAttack;
    }

    public void spinnerCooldown(float cooldown)
    {
        hitBySpinner = true;
        spinnerCounter = cooldown;
    }

    public void takeDamage(float incomingDamage)
    {
        HP -= incomingDamage;
        if(HP <= 0) isDead = true;
        damageDisplayTimer = 6;
        sr.color = new Color(255, 0, 0);
    }

    public void death()
    {

        if(Random.Range(0, 100) < chestChancePercent)
        {
            Instantiate(chest, transform.position, Quaternion.identity);
        }
        SpawnedBlood = Instantiate(Blood, transform.position, Quaternion.identity);
        Destroy(SpawnedBlood, 1.7f);
        // Do stats stuff and whatnot her
        gc.addXP(10);
        Destroy(gameObject);

    }
}
