using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //enemy ATK
    public int attack = 10;
    public float attackBetweenTime = 0.5f;
    float timer;
    GameObject player;
    PlayerHealth playerHealth;
    bool isInRange;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > attackBetweenTime && isInRange)
        {
            Attack();
        }
        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }

    }
    void Attack()
    {
        timer = 0;
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.onAttack(attack);
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject == player)
        {
            isInRange = true;
        }
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject == player)
        {
            isInRange = false;
        }
    }
}
