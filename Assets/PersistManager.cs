using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistManager : MonoBehaviour
{
    private static PersistManager _instance;
    public static PersistManager Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public enum GameStatus
    {
        Win, Fail
    }

    public GameStatus status;
    public int currentLevelIndex;
}
