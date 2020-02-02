using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    public GameObject menuPanel;
    public Image fadeInPanel;

    private void Update()
    {
        fadeInPanel.enabled = true;
        fadeInPanel.color = Color.Lerp(fadeInPanel.color, Color.clear, Time.deltaTime);

        if (fadeInPanel.color.a <= 0.1f)
        {
            fadeInPanel.enabled = false;
        }
    }

    private void Start()
    {
        menuPanel.SetActive(false);
        PersistManager.Instance.currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
