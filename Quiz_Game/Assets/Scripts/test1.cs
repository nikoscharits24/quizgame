
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class test1 : MonoBehaviour
{
    
    public float proximityThreshold = 2f;
    public QuizPopUp quizPopUp;
    public int targetScore;
    public int currentScore;
    public Text scoreText;






    void Start()
    {
        InitializeGame();
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
        


        // implemet win screen
        if (currentScore == 5)
        {
            Debug.Log("You win!");
            
        }
        //keep going if score doesn't match win score
        else if (currentScore < 5)
        {

            currentScore++;

        }
    }

    public void OnInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerVeryNear())
        {
            quizPopUp.gameObject.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }

    }
    void Update()
    {
        OnInteraction();
        

    }

    bool IsPlayerVeryNear()
    {
        return Vector3.Distance(transform.position, Camera.main.transform.position) < proximityThreshold;
    }
}