using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    NavMeshAgent Nav;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Nav = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth = player.GetComponent<PlayerHealth>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            Nav.SetDestination(player.position);
        }
        else
        {
            Nav.enabled = false;
        }
    }
}
