using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenus : MonoBehaviour
{
    public GameObject successScreen;
    public GameObject gameOverScreen;

    public GameObject nextButton;

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
        successScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        StartCoroutine(EnableUI());
    }

    IEnumerator EnableUI()
    {
        yield return new WaitForSeconds(1.0f);
        if (PersistManager.Instance.status == PersistManager.GameStatus.Win)
        {
            SuccessScreen();
        }
        else if (PersistManager.Instance.status == PersistManager.GameStatus.Fail)
        {
            GameOverScreen();
        }
    }

    public void SuccessScreen()
    {
        successScreen.SetActive(true);
        gameOverScreen.SetActive(false);

        if (SceneManager.GetSceneByBuildIndex(SceneManager.sceneCountInBuildSettings - 1) == SceneManager.GetSceneByBuildIndex(PersistManager.Instance.currentLevelIndex))
        {
            nextButton.SetActive(false);
        }
    }

    public void GameOverScreen()
    {
        successScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void MenuScreen()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void RetryScreen()
    {
        Debug.Log("RetryScreen");
        SceneManager.LoadSceneAsync(PersistManager.Instance.currentLevelIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(PersistManager.Instance.currentLevelIndex + 1);
        Debug.Log("NextLevel");
    }
}
