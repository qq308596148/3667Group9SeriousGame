using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    Animator anim;
    public float restartTimer ;
    public float currentTime;
    public Text timeDis;
    public GameObject button;
    private LevelInfo stop;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GameObject  ScoreObject  = GameObject.FindWithTag("GameController");
        stop=ScoreObject. GetComponent<LevelInfo>();
    }
    private void Awake() {
        currentTime = restartTimer;
        timeDis.text = restartTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.currentHealth <= 0)
        {
            stop.notLive();
            anim.SetTrigger("GameOver");
            currentTime -= Time.deltaTime;
            timeDis.text = "Count Down 100s To Restart :" + ((int)currentTime).ToString();

            if(currentTime <= 0)
            {  
                SceneManager.LoadScene("GAME");
            }
        }
    }
}
