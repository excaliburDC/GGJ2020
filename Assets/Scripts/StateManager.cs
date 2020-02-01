using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    private static StateManager _instance;
    public static StateManager Instance { get => _instance; set => _instance = value; }

    public enum States { None, Create, Play }

    private States state;
    public States State { get => state; set => state = value; }

    public Button executeBtn;

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
        if (State == States.Create)
        {
            executeBtn.interactable = true;
            executeBtn.GetComponentInChildren<Text>().text = "Execute!";
        }
        else
        {
            executeBtn.interactable = false;
            executeBtn.GetComponentInChildren<Text>().text = "Compiling!";
        }
    }

    public void ChangeState(int state)
    {
        State = (States)state;
        Debug.Log(State);
    }
}
