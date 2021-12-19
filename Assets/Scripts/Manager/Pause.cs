using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject ingameMenu;
    // Start is called before the first frame update
    void Start()
    {
        ingameMenu.SetActive(false);
    }
    public void OnPause()
    {
        Time.timeScale = 0.0f;
        ingameMenu.SetActive(true);
    }

    public void onResume()
    {
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
    }
    
    public void onRestart()
    {
        SceneManager.LoadScene("GAME");
        PersistentData.Instance.SetScore(0);
        PersistentData.Instance.SetTime(0f);
        Time.timeScale = 1f;
    }
}