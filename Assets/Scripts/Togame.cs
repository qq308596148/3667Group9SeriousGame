using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Togame : MonoBehaviour
{
    [SerializeField] InputField input;
    void Start()
    {
        string pName = PersistentData.Instance.GetName();
        // if (pName != "")
        // {
        //     input.placeholder.GetComponent<Text>().text = pName;
        // }
    }
    public void Play()
    {
        Time.timeScale = 1f;
        string playerName = input.text;
        PersistentData.Instance.SetName(playerName);
        if(playerName.Length != 0){
            SceneManager.LoadScene("BeforePlay");
            PersistentData.Instance.SetScore(0);
            PersistentData.Instance.SetTime(0f);
        }
    }
    public void Rank()
    {
        SceneManager.LoadScene("HighScore");
    }

}