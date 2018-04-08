using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerController : PlatformerCharacter2D
{

    public bool canMove = true;
    public bool isInteracting = false;
    public TextBoxManager choiceDialogBox;
    private InteractableObjectController currenInteractable;

    private void Interact(InteractableObjectController interactableObject)
    {
        interactableObject.interacting = true;
        isInteracting = true;
        choiceDialogBox.SetChoices(currenInteractable.choices);
        choiceDialogBox.EnableTextBox();
        Debug.Log("You're doing it fam, you're interacting.");
        // do all the stuff for the interacting.
        // this should be different for each object.
    }

    private void EndInteract(InteractableObjectController interactableObject)
    {
        interactableObject.interacting = false;
        isInteracting = false;
        Debug.Log("You have done what you came to do.");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var interactableObject = other.GetComponentInParent<InteractableObjectController>();
        if (interactableObject != null)
        {
            Debug.Log("Object Entered the InteractableObjectCollider for " + interactableObject.display_name);
            interactableObject.Display_Interaction_text(true);
            currenInteractable = interactableObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var interactableObject = other.GetComponentInParent<InteractableObjectController>();
        if (interactableObject != null)
        {
            Debug.Log("Object Exited the InteractableObjectCollider for " + interactableObject.display_name);
            interactableObject.Display_Interaction_text(false);
            currenInteractable = null;
        }

    }

    private void Update()
    {

        if (Input.GetButtonUp("Action") && isInteracting != true && currenInteractable != null)
        {
            Debug.Log("Pressed Action while display Interaction is true");
            //do stuff if the the display_text is showing
            Interact(currenInteractable);
        }

        if (canMove == false || isInteracting == true)
        {
            Debug.Log("can't move rn");
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else {
            choiceDialogBox.choices = null;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
