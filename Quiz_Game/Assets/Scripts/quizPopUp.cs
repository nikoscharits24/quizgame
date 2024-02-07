using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuizPopUp : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerTexts;
   


    private void Start()
    {
        gameObject.SetActive(false);
    }


    //questions and answers
    private int currentQuestionIndex = 0;
    private string[] questions = { 
        "What is the capital of France?", 
        "Which of these is not a programming language?", 
        "In greek mythology, who is one of the brothers of Zeus?"    
    };
    private string[][] answers = {
        new string[] { "Paris", "Madrid", "Berlin", "Oslo" },
        new string[] { "Python", "Java", "Javascript", "HTML" },
        new string[] { "Ares", "Prometheus", "Hades", "Athena" }
    };
    private int[] correctAnswers = { 0, 3, 2,}; // Index of the correct answer for each question



    
    //questions loop
    public void ShowNextQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];

            for (int i = 0; i < answerTexts.Length; i++)
            {
                answerTexts[i].text = answers[currentQuestionIndex][i];
            }

            currentQuestionIndex++;
        }
        else
        {
            Debug.LogWarning("No more questions!");
            gameObject.SetActive(false);
        }
    }
    //answer check
    public bool CheckAnswer(int selectedAnswerIndex)
    {
        if (selectedAnswerIndex == correctAnswers[currentQuestionIndex - 1])
        {
            Debug.Log("Correct!");
            return true;
        }
        else
        {
            Debug.Log("Incorrect!");
            return false;
        }
    }
}
