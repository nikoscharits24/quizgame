using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizPopUp : MonoBehaviour
{

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        gameObject.SetActive(true);
    }
}
