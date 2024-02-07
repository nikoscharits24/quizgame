
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class test1 : MonoBehaviour
{

    public float proximityThreshold = 2f;
    public QuizPopUp quizPopUp;
    public int targetScore;
    public int currentScore;
    public Text scoreText;
    public Text targetScoreText;





    void Start()
    {
        InitializeGame();
        MyScore();
        
    }

    void InitializeGame()
    {
        GenerateTargetScore();
    }

    void GenerateTargetScore()
    {
        targetScore = 5;
    }



    void UpdateTargetScore()
    {
        scoreText.text = "Your score is : " + targetScore.ToString();

    }


    public void CheckCurrentScore(int currentScore)
    {

        // implement win screen
        if (currentScore == targetScore)
        {
            Debug.Log("You win!");

        }

    }

    public void CorrectAnswerSelected()
    {
        currentScore++;
        UpdateTargetScore();
        CheckCurrentScore(currentScore);
    }

    public void OnInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerVeryNear())
        {
            quizPopUp.gameObject.SetActive(true);
            quizPopUp.ShowNextQuestion();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }

    }
    void Update()
    {
        OnInteraction();
    }

    public void MyScore()
    {
        scoreText.text = $"YOUR SCORE: {currentScore.ToString()}";
        targetScoreText.text = $"TARGET SCORE: {targetScore.ToString()}";
    }

    bool IsPlayerVeryNear()
    {
        return Vector3.Distance(transform.position, Camera.main.transform.position) < proximityThreshold;
    }


    //handle quiz answers

    public void OnButtonClick(int answerIndex)
    {
        bool isCorrect = quizPopUp.CheckAnswer(answerIndex);
        // Perform further actions based on the validation result
        if (isCorrect)
        {
            // Handle correct answer
            Debug.Log("Correct answer selected!");
            // Add code here to increment score or move to the next question
        }
        else
        {
            // Handle incorrect answer
            Debug.Log("Incorrect answer selected!");
            // Add code here to provide feedback or take other actions
        }
    }
}