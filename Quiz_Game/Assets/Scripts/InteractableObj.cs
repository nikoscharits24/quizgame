using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public void Interact()
    {
        // Add your interaction logic here
        Debug.Log("Interacting with " + gameObject.name);
    }
}


