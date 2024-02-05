using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class test1 : MonoBehaviour
{
    
    public float proximityThreshold = 2f;
    public QuizPopUp quizPopUp;

    public void OnInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerVeryNear())
        {
            quizPopUp.gameObject.SetActive(true);
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