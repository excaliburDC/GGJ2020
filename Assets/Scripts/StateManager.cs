﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    private static StateManager _instance;
    public static StateManager Instance { get => _instance; set => _instance = value; }

    public enum States { None, Create, Play, Win, Fail }

    private States state;
    public States State { get => state; set => state = value; }

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
        State = States.Create;
    }

    private void Update()
    {

        switch (state)
        {
            case States.None:
                break;
            case States.Create:
                timerRunning = true;
                executeBtn.interactable = true;
                executeBtn.GetComponentInChildren<Text>().text = "Execute!";
                break;
            case States.Play:
                executeBtn.interactable = false;
                executeBtn.GetComponentInChildren<Text>().text = "Compiling!";
                player.GetComponent<PlayerController>().ActivatePlayer();
                break;
            case States.Win:
                Debug.Log("Correct");
                break;
            case States.Fail:
                Debug.Log("Incorrect");
                break;
        }
    }

    public void ChangeState(int state)
    {
        State = (States)state;
        Debug.Log(State);
    }

    private void CreateGame()
    {

    }

    private void PlayGame()
    {

    }

    private void WinGame()
    {

    }

    private void FailGame()
    {

    }
}