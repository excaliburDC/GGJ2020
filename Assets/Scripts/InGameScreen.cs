using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameScreen : MonoBehaviour
{
    public GameObject successScreen;
    public GameObject gameOverScreen;

   
    public void Start()
    {
        SuccessScreen();
    }
    public void SuccessScreen()
    {
       
        successScreen.SetActive(true);
    }
    public void GameOverScreen()
    {
       
            gameOverScreen.SetActive(true);
    }
    public void MenuScreen()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }
    public void RetryScreen()
    {
        Debug.Log("RetryScreen");
    }
    public void RetryAtLevel()
    {
        Debug.Log("RetryAtLeve");
    }
    public void NextLevel()
    {
        Debug.Log("NextLevel");
    }
}
