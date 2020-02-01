using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeLeft;
    public string beginText;
    private Text timerText;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        if (StateManager.Instance.timerRunning)
        {
            timeLeft -= Time.unscaledDeltaTime;

            string minutes = Mathf.Floor(timeLeft / 60).ToString("00");
            string seconds = (timeLeft % 60).ToString("00");

            timerText.text = beginText + minutes + ":" + seconds + " minutes.";

            //timeLeft -= Time.unscaledDeltaTime;
            //timerText.text = timeLeft.ToString("0");
            if (timeLeft < 0f)
            {
                StateManager.Instance.timeOut = true;
                StateManager.Instance.timerRunning = false;
            }
        }
    }
}
