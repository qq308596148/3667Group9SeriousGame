using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //max hp
    public int startingHealth = 100;
    public int currentHealth;
    public Slider slider;
    public Image HurtImage;
    AudioSource playerAudio;
    Animator anim;
    PlayerMovement playerMovement;
    public AudioClip deathClip;
    bool isDamage;
    PlayerShooting playershoot;
    public Color falshColor = new Color(1f,0f,0f,0.1f);

    float indirect = 6f;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        playerMovement = GetComponent<PlayerMovement>();
        playershoot = GetComponentInChildren<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDamage)
        {
            HurtImage.color = falshColor; 
        }
        else
        {
            HurtImage.color = Color.Lerp(HurtImage.color, Color.clear, indirect* Time.deltaTime);
        }
        isDamage = false;
    }
    public void onAttack(int damage)
    {   //when player hurt by enmey reduce hp volume 
        currentHealth -= damage;
        isDamage = true;
        slider.value = currentHealth;
        //Injured sound
        playerAudio.Play();

        if(currentHealth <= 0)
        {
            Dead();
        }
    }
    void Dead()
    {
        playershoot.disableGun();
        playerAudio.clip = deathClip ;
        playerAudio.Play();
        anim.SetTrigger("Die");
        playerMovement.enabled = false;
        playershoot.enabled = false;
    }
}
