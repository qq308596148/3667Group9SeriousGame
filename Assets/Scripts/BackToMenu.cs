using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void Reset() {
        PersistentData.Instance.Clean();
    }
    public void HSToMenu()
    {
        PersistentData.Instance.SetName("");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}