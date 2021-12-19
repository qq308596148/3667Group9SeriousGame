using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SaveHighScores : MonoBehaviour
{
    public const int NUM_HIGH_SCORES = 5;
    public const string NAME_KEY = "HSName";
    public const string SCORE_KEY = "HScore";
    public const string TIME_KEY = "HSTime";
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] float playerTime;

    [SerializeField] Text[] nameTexts;
    [SerializeField] Text[] scoreTexts;
    [SerializeField] Text[] timeTexts;


    // Start is called before the first frame update
    void Start()
    {
        if(PersistentData.Instance.GetName() != ""){
            playerName = PersistentData.Instance.GetName();
            playerScore = PersistentData.Instance.GetScore();
            playerTime = PersistentData.Instance.GetTime();
            SaveScore();
        }

    }

    public void SaveScore()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;
            string currentTimeKey = TIME_KEY + i;

            if (PlayerPrefs.HasKey(currentTimeKey))
            {
                float currentTime = PlayerPrefs.GetFloat(currentTimeKey);
                if (playerTime < currentTime||playerTime == 0)
                {
                    float tempTime = currentTime;
                    string tempName = PlayerPrefs.GetString(currentNameKey);
                    int tempScore = PlayerPrefs.GetInt(currentScoreKey);

                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);
                    PlayerPrefs.SetFloat(currentTimeKey,playerTime);

                    playerScore = tempScore;
                    playerName = tempName;
                    playerTime = tempTime;

                }
                if((int)playerTime == (int)currentTime)
                {
                    int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                    if (playerScore > currentScore)
                    {
                        int tempScore = currentScore;
                        string tempName = PlayerPrefs.GetString(currentNameKey);
                        float tempTime = PlayerPrefs.GetFloat(currentTimeKey);                

                        PlayerPrefs.SetString(currentNameKey, playerName);
                        PlayerPrefs.SetInt(currentScoreKey, playerScore);
                        PlayerPrefs.SetFloat(currentTimeKey,playerTime);

                        playerScore = tempScore;
                        playerName = tempName;
                        playerTime = tempTime;

                    }
                }
            }

            else
            {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                PlayerPrefs.SetFloat(currentTimeKey,playerTime);
                return;
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY + i);
            scoreTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY + i).ToString();
            timeTexts[i].text = (Math.Round(PlayerPrefs.GetFloat(TIME_KEY + i),2)).ToString();
        }
        
    }

    


}
