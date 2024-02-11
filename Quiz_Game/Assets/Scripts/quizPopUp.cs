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
        "According to greek mythology, who is the brother of Zeus?"
    };
    private string[][] answers = {
        new string[] { "Paris", "Madrid", "Berlin", "Oslo" },
        new string[] { "Python", "Java", "Javascript", "HTML" },
        new string[] { "Ares", "Prometheus", "Hades", "Athena" }
    };
    private int[] correctAnswers = { 0, 3, 2,}; // Index of the correct answer for each question
    

    public void NextQuestion()
    {
        currentQuestionIndex++;
        ShowNextQuestion();
        foreach (Button button in test1.Instance.buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }

    }



    //questions loop
    public void ShowNextQuestion()
    {

       
        if (currentQuestionIndex < questions.Length)
        {
            Debug.Log($"Showing question. {currentQuestionIndex + 1} ");
            questionText.text = questions[currentQuestionIndex];

            for (int i = 0; i < answerTexts.Length; i++)
            {
                answerTexts[i].text = answers[currentQuestionIndex][i];

            }
          


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

        if (selectedAnswerIndex == correctAnswers[currentQuestionIndex])
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
