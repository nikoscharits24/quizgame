using UnityEngine;

public class Interaction : MonoBehaviour
{
    public QuizManager quizManager;

    private bool isInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player entered the interaction zone.");
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interaction key pressed.");
            quizManager.StartQuiz();
        }
    }
}