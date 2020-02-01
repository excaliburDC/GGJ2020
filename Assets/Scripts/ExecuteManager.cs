using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteManager : MonoBehaviour
{
    private string userAnswer;

    public string correctAnswer;

    public void CheckAnswer()
    {
        if (correctAnswer.ToUpper().Equals(userAnswer.ToUpper()))
        {
            // Next Level
            Debug.Log("Correct!");
        }
        else
        {
            // End Screen
            Debug.Log("Incorrect!");
        }
    }
}
