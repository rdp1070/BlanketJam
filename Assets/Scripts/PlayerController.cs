using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerController : PlatformerCharacter2D
{

    public bool canMove = true;
    public bool isInteracting = true;
    public TextBoxManager choiceDialogBox;

    public new void Move(float move, bool crouch, bool jump)
    {
        if (canMove == false || isInteracting == true) {
            move = 0f;
            choiceDialogBox.EnableTextBox();
        }

        base.Move(move, crouch, jump);
    }

    private void Interact(InteractableObjectController interactableObject)
    {
        interactableObject.interacting = true;
        isInteracting = true;
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
            interactableObject.display_Interaction = true;
            interactableObject.SetInteractionText();
            interactableObject.Display_Interaction_text(interactableObject.display_Interaction);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var interactableObject = other.GetComponentInParent<InteractableObjectController>();
        if (interactableObject != null)
        {
            Debug.Log("Object Entered the InteractableObjectCollider for " + interactableObject.display_name);
            interactableObject.display_Interaction = true;
            interactableObject.SetInteractionText();
            interactableObject.Display_Interaction_text(interactableObject.display_Interaction);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var interactableObject = collision.GetComponentInParent<InteractableObjectController>();
        // this is where we put the code for displaying the text above the sprite.
        // Something to the effect of Press 'interact' button to interact. 
        // then we trigger the dialouge related to that thing, and probably the animation as well.
        if (Input.GetButtonUp("Action") && isInteracting != true && interactableObject != null)
        {
            Debug.Log("Pressed Action while display Interaction is true");
            //do stuff if the the display_text is showing
            Interact(interactableObject);
        }

    }
}
