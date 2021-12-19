using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{

    public float Timer ;
    public float currentTime;
    [SerializeField] Text timeDis;
    [SerializeField] Text scoreDis;

    [SerializeField] string playerName;
    [SerializeField] int score;
    [SerializeField] float time;
    public bool stillLive = true;
    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        score = PersistentData.Instance.GetScore();
        time = PersistentData.Instance.GetTime();

        DisplayTime();
        DisplayScore();

    }
    private void Awake() {
        currentTime = Timer;
        timeDis.text = Timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0f && stillLive.Equals(true)){
        currentTime -= Time.deltaTime;
        DisplayTime();
        PersistentData.Instance.SetTime(currentTime);
        }
        if (currentTime <= 0)
        {
            PersistentData.Instance.SetTime(currentTime);
            SceneManager.LoadScene("AfterPlay");
        }
    }
    public void notLive(){
        stillLive=false;
    }
    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("score " + score);
        DisplayScore();
        PersistentData.Instance.SetScore(score);
    }
    
    public void DisplayScore()
    {
        scoreDis.text = "Score: " + score;
    }
    public void DisplayTime()
    {
        timeDis.text = "Time: " +  ((int)currentTime).ToString();
;
    }
}