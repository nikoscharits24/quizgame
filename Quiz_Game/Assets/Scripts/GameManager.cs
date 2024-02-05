using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject quizWindow;
    public Text questionText;
    public Button[] answerButtons;

    private string correctAnswer = "YourCorrectAnswer"; 
    public void StartQuiz()
    {
        quizWindow.SetActive(true);

        
        questionText.text = "What is the capital of France?";

        
        string[] answerChoices = { "Paris", "Berlin", "London", "Madrid" };

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = answerChoices[i];
        }
    }

    public void CheckAnswer(string selectedAnswer)
    {
        if (selectedAnswer.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Correct Answer!");
            // Add your correct answer handling logic here
        }
        else
        {
            Debug.Log("Wrong Answer. Try again!");
            // Add your wrong answer handling logic here
        }

        quizWindow.SetActive(false);
    }
}
