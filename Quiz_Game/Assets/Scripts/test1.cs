
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class test1 : MonoBehaviour
{
    public static test1 Instance;
    public float proximityThreshold = 2f;
    public QuizPopUp quizPopUp;
    public int targetScore;
    public int currentScore;
    public Text scoreText;
    public Text targetScoreText;
    public Button[] buttons;





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
        foreach (Button button in buttons)
        {
            button.GetComponent<Button>().interactable = true;
        }

       

        bool isCorrect = quizPopUp.CheckAnswer(answerIndex);
        if (isCorrect)
        {
            //correct answer +points
            currentScore++;
            MyScore();

            foreach (Button button in buttons)
            {
                button.GetComponent<Button>().interactable = false;
            }

        }
        else
        {
            //incorrect answer no points
           
            Debug.Log("Incorrect answer selected!");
            foreach (Button button in buttons)
            {
                button.GetComponent<Button>().interactable = false;
            }

        }
    }
}