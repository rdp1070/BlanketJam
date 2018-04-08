using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class InteractableObjectController : MonoBehaviour {

    public bool display_Interaction;
    public bool interacting;
    Vector3 vector_offset;
    public string display_name;
    public string display_action_text;
    public Text Interaction_Message;
    public string minigame_scene_name;

    public ChoiceController[] choices;

    // this should have a list of "dialouge options"
    // this should also have "intro dialouge"
    // this should also have "outro dialouge"

	// Use this for initialization
	void Start () {
        choices = GetComponentsInChildren<ChoiceController>();
        display_Interaction = false;
        interacting = false;
        var height = (this.transform.localScale.y / GetComponent<SpriteRenderer>().sprite.bounds.size.y);
        var width = (this.transform.localScale.x / GetComponent<SpriteRenderer>().sprite.bounds.size.x);
        vector_offset = new Vector3(width / 2, height);
        SetInteractionText();
	}
    
    // Update is called once per frame
    void Update () {
        if (display_Interaction == true)
        {
            // this is where we put the code for displaying the text above the sprite.
            // Something to the effect of Press 'interact' button to interact. 
            // then we trigger the dialouge related to that thing, and probably the animation as well.
            if (Input.GetButtonUp("Action") && interacting != true)
            {
                Debug.Log("Pressed Action while display Interaction is true");
                //do stuff if the the display_text is showing
                Interact();
            }
        }
	}

    private void Display_Interaction_text(bool visible = true) {
        // make a new text object that hovers above the interactable object.
        // It should say "press [interact button] to [do action]|[use item]"
        SetInteractionText();
        Interaction_Message.gameObject.SetActive(visible);
        // new text item that floats above current location
    }

    private void SetInteractionText() {
        Interaction_Message.rectTransform.position = transform.position + vector_offset;
        Interaction_Message.text = "Press Interact Button to " + display_action_text;            
    }

    private void Interact()
    {
        interacting = true;
        Debug.Log("You're doing it fam, you're interacting.");
        // do all the stuff for the interacting.
        // this should be different for each object.
    }

    private void EndInteract() {

        interacting = false;
        Debug.Log("You have done what you came to do.");

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object Entered the InteractableObjectCollider for "+ name);
        display_Interaction = true;
        SetInteractionText();
        Display_Interaction_text(display_Interaction);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Object Exited the InteractableObjectCollider " + name);
        display_Interaction = false;
        Display_Interaction_text(display_Interaction);
    }

    void OnMouseOver()
    {
        // do nothing rn
        // later maybe make the object glow a little?
    }

    private void OnMouseUp()
    {
        if (display_Interaction == true) {
            // now you should be interacting with the thing.
            Debug.Log("You clicked me while we overlap.");
        }
    }

}
