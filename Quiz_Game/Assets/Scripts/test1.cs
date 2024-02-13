
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
    private bool[] questionAnswered;
    public int counter;
    public Texture2D cursorTexture;
    public Light[] lights;
    public GameObject door;

    //screens
    public GameObject winScreen;
    public GameObject loseScreen;

    //audio
    public AudioClip openDoor;
    public AudioSource audioSource;
    

    


    void Start()
    {
        InitializeGame();
        MyScore();

        Cursor.visible = false;
        if (cursorTexture != null)
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }

    }

    void InitializeGame()
    {
        GenerateTargetScore();
        questionAnswered = new bool[quizPopUp.questions.Length];
    }

    void GenerateTargetScore()
    {
        targetScore = 3;
    }



    void UpdateTargetScore()
    {
        scoreText.text = "Your score is : " + targetScore.ToString();

    }


    public void CheckCurrentScore(int currentScore)
    {

        // implement win screen
        if (counter == 3 && currentScore == targetScore)
        {
            Debug.Log("You win!");
            quizPopUp.gameObject.SetActive(false);
            ShowWinScreen();
            ActivateLightsAndDoor();
        }
         else if (counter == 3 && currentScore < targetScore)
        {
            Debug.Log("You lose");
            quizPopUp.gameObject.SetActive(false);
            ShowLoseScreen();
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

    //screen functions
    void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }
    public void DeleteWinScreen()
    {
        winScreen.SetActive(false);
    }
    void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }


    //handle quiz answers

    public void OnButtonClick(int answerIndex)
    {
        counter++;
        

        if (!questionAnswered[quizPopUp.currentQuestionIndex]) 
        {
            bool isCorrect = quizPopUp.CheckAnswer(answerIndex);
            if (isCorrect)
            {
                currentScore++;               
                MyScore();
                
            }
            questionAnswered[quizPopUp.currentQuestionIndex] = true;
            CheckCurrentScore(currentScore);
        }
    }


    void ActivateLightsAndDoor()
    {
        foreach (Light light in lights)
        {
            light.enabled = true;
            light.intensity = 10f;
            light.color = Color.green;
        }

        if (door != null)
        {
            door.SetActive(false); // Open the door
            audioSource.PlayOneShot(openDoor);
        }
    }
}