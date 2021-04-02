using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnInteract;
    public UnityEvent OnExit;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript.closestInteractableObject = this;
        OnEnter.Invoke();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (PlayerScript.closestInteractableObject == this)
        {
            OnExit.Invoke();
            PlayerScript.closestInteractableObject = null;
        }
    }

}
