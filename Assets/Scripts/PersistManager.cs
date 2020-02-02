using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool videoStarted = false;

    private void Update()
    {
        if (!videoStarted && SceneManager.GetActiveScene().name.Equals("Crash"))
        {
            GameObject crashVideo = GameObject.Find("Video");
            UnityEngine.Video.VideoPlayer videoPlayer = crashVideo.GetComponent<UnityEngine.Video.VideoPlayer>();

            StartCoroutine(PlayVideo(videoPlayer));
        }
    }

    IEnumerator PlayVideo(UnityEngine.Video.VideoPlayer videoPlayer)
    {
        videoStarted = true;
        videoPlayer.Play();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync("Level 1");
    }
}
