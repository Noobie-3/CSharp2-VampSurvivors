using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    // Player's weapons
    GameObject weaponSpawner;
    TestSpawn spinWeapon;

    //Variables for leveling up
    public uint level = 1;
    public uint experienceToNextLevel = 100;
    public uint xpGained = 0;
    private uint XP = 0;
    private List<string> lvlOptions = new List<string> {"Spinner", "Dagger", "Shield", "Sword", "Lightning"};

    // Variables for health
    public uint maxHealth = 100;
    private int currentHealth = 100;

    //These variables are multipliers for the perks.
    public float moveSpeed = 4;
    public float might = 1;
    public float areaOfWeapon = 1;
    public float cooldown = 1;
    public float healthRecovery = 0;
    private AudioSource audioData;

    void Awake()
    {
        weaponSpawner = GameObject.Find("WeaponSpawner");
        spinWeapon = weaponSpawner.GetComponent<TestSpawn>();
        audioData = GetComponent<AudioSource>();

    }

    public void NewScene()
    {
        SceneManager.LoadScene("Death_Screen");
    }

    public void takeDamage(uint damage)
    {
        currentHealth -= (int)damage;

        if(currentHealth <= 0)
        {
            NewScene();

        }
    }

    public void heal(uint health)
    {
        currentHealth += (int)health;
        if(currentHealth > maxHealth) currentHealth = (int)maxHealth;
    }

    // Chest gives half of the experience needed to level up
    public void openChest()
    {
        addXP((uint)Mathf.FloorToInt(experienceToNextLevel / 2));
    }

    public void addXP(uint amount)
    {
        //add xp
        XP += amount;
        xpGained += amount;
        if(XP >= experienceToNextLevel)
        {
            //enough xp to level up
            level++;
            audioData.Play();
            XP -= experienceToNextLevel;
            //adds more to the experience needed to level up (scaling)
            experienceToNextLevel += 10;

            if(lvlOptions.Count > 0)
            {
                int option = Random.Range(0, lvlOptions.Count - 1);
                switch (lvlOptions[option])
                {
                    case "Spinner":
                        if (spinWeapon.WeaponLevel++ == 8) lvlOptions.RemoveAt(option);
                        break;
                    case "Dagger":
                        weaponSpawner.GetComponent<DaggerThrow>().enabled = true;
                        lvlOptions.RemoveAt(option);
                        break;
                    case "Shield":
                        weaponSpawner.GetComponent<Shield_Spawner>().enabled = true;
                        lvlOptions.RemoveAt(option);
                        break;
                    case "Sword":
                        weaponSpawner.GetComponent<Spawn_Sword>().enabled = true;
                        lvlOptions.RemoveAt(option);
                        break;
                    case "Lightning":
                        weaponSpawner.GetComponent<Lightning_Spawner>().enabled = true;
                        lvlOptions.RemoveAt(option);
                        break;
                }
            }
        }
    }

    // Just for your Sir Lehman ->
    public int getHealth()
    {
        return currentHealth;
    }

    public uint getXP()
    {
        return XP;
    }
    // <-

    public double upgradePerk(double daPerk)
    {
        daPerk += .05;
        return daPerk;
    }
}
   
