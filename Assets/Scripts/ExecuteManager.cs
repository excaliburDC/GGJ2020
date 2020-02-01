using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteManager : MonoBehaviour
{
    private static ExecuteManager _instance;
    public static ExecuteManager Instance { get => _instance; set => _instance = value; }

    private string userAnswer;

    public string correctAnswer;

    public Text answerText;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    private void Start()
    {
        answerText.text = "Current Attempt: ";
    }

    public void CheckAnswer()
    {
        // End game if timeout.
        if (StateManager.Instance.timeOut)
        {
            if (IsAnswerCorrect())
            {
                StateManager.Instance.State = StateManager.States.Win;
            }
            else
            {
                StateManager.Instance.State = StateManager.States.Fail;
            }
        }

        // End game if all characters collected.
        if (correctAnswer.Length == userAnswer.Length)
        {
            // Check if correct
            if (IsAnswerCorrect())
            {
                StateManager.Instance.State = StateManager.States.Win;
            }
            else
            {
                StateManager.Instance.State = StateManager.States.Fail;
            }
        }
    }

    public void AddToAnswer(string alpha)
    {
        userAnswer += alpha.Trim();
        answerText.text += alpha.Trim().ToUpper();
    }

    private bool IsAnswerCorrect()
    {
        return correctAnswer.ToUpper().Equals(userAnswer.ToUpper());
    }
}
