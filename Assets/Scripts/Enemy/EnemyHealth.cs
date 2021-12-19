using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    AudioSource enemyAudioSource;
    Animator anim;
    public AudioClip deathClip;
    bool isDead;
    CapsuleCollider capCollider;
    Rigidbody rdbody;
    public int point = 10;
    private LevelInfo Score;

    EnemyAttack enemyAtk;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        enemyAudioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        enemyAtk = GetComponent<EnemyAttack>();
        capCollider = GetComponent<CapsuleCollider>();
        rdbody = GetComponent<Rigidbody>();
        GameObject  ScoreObject  = GameObject.FindWithTag("GameController");
        Score=ScoreObject. GetComponent<LevelInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAttack (int damage)
    {
        if(isDead)
        {
            return;
        }
        currentHealth -= damage;
        enemyAudioSource.Play();
        if(currentHealth <= 0)
        {
            Dead();
        }
    }
    void Dead()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        enemyAudioSource.clip = deathClip;
        enemyAudioSource.Play();
        enemyAtk.enabled = false;
        capCollider.isTrigger = true;
        rdbody.isKinematic = true;

    }
    public void StartSinking()
    {
        Destroy(gameObject,1);
        Score.AddPoints(point);
    }
}
