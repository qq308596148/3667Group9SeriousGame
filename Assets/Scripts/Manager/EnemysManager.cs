using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 5f;
    public Transform[] spawnPoint;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        if(playerHealth.currentHealth <= 0)
        {
            return;
        }
        InvokeRepeating("Spawn",spawnTime, spawnTime);
    }
    void Spawn()
    {
        int index = Random.Range(0, spawnPoint.Length);
        Instantiate(enemy, spawnPoint[index].position,spawnPoint[index].rotation);
    }


}
