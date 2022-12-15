using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    // References to the below GameObjects are loaded dynamically
    GameObject player;
    List<GameObject> spawnPoints;
    List<GameObject> campfireSpawns;

    int intervalTracker = 50;
    public int secondsPassed = 0;
    public int campfireChance;

    public GameObject spider;
    public GameObject hornet;
    public GameObject chest;
    public GameObject campfire;

    public int wave = 1;
    public int phase = 1;
    public int enemiesInWave = 10;
    public int hornetPercentage = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawn"));

        // ooga booga caveman style
        campfireSpawns = new List<GameObject>();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i].name == "Spawn_Point_Left_1" ||
               spawnPoints[i].name == "Spawn_Point_Left_9" ||
               spawnPoints[i].name == "Spawn_Point_Right_1" ||
               spawnPoints[i].name == "Spawn_Point_Right_9")
            {
                campfireSpawns.Add(spawnPoints[i]);
            }
            
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if (intervalTracker-- == 0)
        {
            intervalTracker = 50;
            secondsPassed += 1;
            // Call OneSecondUpdate() every second
            OneSecondUpdate();
        }
    }

    void OneSecondUpdate()
    {
        // Every Enemy has a child GameObject also tagged "Enemy", so divide result in half
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length / 2;

        if (enemyCount < enemiesInWave)
        {
            int difference = enemiesInWave - enemyCount;
            if (difference >= 18)
            {
                spawnEnemies(18, spider);
            }
            else
            {
                spawnEnemies(difference, spider);
            }
        }

        if (secondsPassed % 60 == 0)
        {
            wave++;
            enemiesInWave += 10;
        }

        if (secondsPassed % 20 == 0)
        {
            // Campfire spawning
            for(int i = 0; i < campfireSpawns.Count; i++)
            {
                if(Random.Range(0, 100) <= campfireChance)
                {
                    Instantiate(campfire, campfireSpawns[i].transform.position, Quaternion.identity);
                }
            }

            // Wave logic
            switch(phase++)
            {
                case 1:
                    spawnEnemies((int)(.2f * enemiesInWave), hornet);
                    break;
                case 2:
                    spawnEnemies((int)(.5f * enemiesInWave), hornet);
                    break;
                case 3:
                    phase = 1;
                    break;
                default:
                    Debug.Log("Spawning phase logic broketh");
                    break;
            }
        }
    }

    void spawnEnemies(int amount, GameObject enemy)
    {
        List<GameObject> shallowCopy = new List<GameObject>(spawnPoints);
        int index;
        for (int i = 0; i < amount; i++)
        {
            index = Random.Range(0, shallowCopy.Count);
            Instantiate(enemy, shallowCopy[index].transform.position, Quaternion.identity);
            shallowCopy.RemoveAt(index);
            if (shallowCopy.Count == 0)
            {
                shallowCopy = new List<GameObject>(spawnPoints);
            }
        }
    }
}
