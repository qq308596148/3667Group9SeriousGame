using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBattle : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GAME");
        Time.timeScale = 1f;
    }
}