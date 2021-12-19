using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance; 

    void Start()
    {
        PersistentData.Instance = this;
    }

    public void SetTime(float time){
        PlayerPrefs.SetFloat("time",time);
        PlayerPrefs.Save();
    }
    public void SetName(string name)
    {
        PlayerPrefs.SetString("name",name);
        PlayerPrefs.Save();
    }

    public void SetScore(int num)
    {
        PlayerPrefs.SetInt("score",num);
        PlayerPrefs.Save();
    }

    public float GetTime()
    {
        return PlayerPrefs.GetFloat("time");
    }

    public string GetName()
    {
        return PlayerPrefs.GetString("name");
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt("score");
    }
    public void Clean()
    {
        PlayerPrefs.DeleteAll ();   
        Debug.Log("Data reset complete");
    }
}
