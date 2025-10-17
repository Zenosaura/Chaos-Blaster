using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scne : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadTu()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadLevel()
    {
        SceneManager.LoadScene(2);
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quitting now");
    }
}
