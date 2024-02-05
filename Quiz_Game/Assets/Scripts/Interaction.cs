using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float interactionDistance = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Check if the object hit is interactable
            InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();

            if (interactableObject != null)
            {
                interactableObject.Interact();
            }
        }
    }
}
