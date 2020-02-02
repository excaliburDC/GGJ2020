using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    private static StateManager _instance;
    public static StateManager Instance { get => _instance; set => _instance = value; }

    public enum States { None, Create, Play, Win, Fail }
    public States state;

    public enum Modes { Normal, Hardcore }
    public Modes mode = Modes.Normal;

    public Button executeBtn;
    public GameObject player;

    [HideInInspector] public bool timeOut = false;
    [HideInInspector] public bool timerRunning = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    private void Start()
    {
        state = States.Create;
    }

    private void Update()
    {

        switch (state)
        {
            case States.None:
                break;
            case States.Create:
                CreateGame();
                break;
            case States.Play:
                PlayGame();
                break;
            case States.Win:
                WinGame();
                break;
            case States.Fail:
                FailGame();
                break;
        }
    }

    public void ChangeState(int state)
    {
        this.state = (States)state;
    }

    private void CreateGame()
    {
        timerRunning = true;
        executeBtn.interactable = true;
        executeBtn.GetComponentInChildren<Text>().text = "Execute!";
    }

    private void PlayGame()
    {
        executeBtn.interactable = false;
        executeBtn.GetComponentInChildren<Text>().text = "Compiling!";
        player.GetComponent<PlayerController>().ActivatePlayer();
    }

    private void WinGame()
    {
        Debug.Log("Correct");
        timerRunning = false;
        PersistManager.Instance.status = PersistManager.GameStatus.Win;
        SceneManager.LoadSceneAsync("EndGameMenus");
    }

    private void FailGame()
    {
        Debug.Log("Incorrect");
        timerRunning = false;
        PersistManager.Instance.status = PersistManager.GameStatus.Fail;
        SceneManager.LoadSceneAsync("EndGameMenus");
    }
}
