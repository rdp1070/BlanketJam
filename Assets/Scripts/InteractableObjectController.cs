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
        
	}

    public void Display_Interaction_text(bool visible = true) {
        // make a new text object that hovers above the interactable object.
        // It should say "press [interact button] to [do action]|[use item]"
        SetInteractionText();
        Interaction_Message.gameObject.SetActive(visible);
        // new text item that floats above current location
    }

    public void SetInteractionText() {
        Interaction_Message.rectTransform.position = transform.position + vector_offset;
        Interaction_Message.text = "Press Interact Button to " + display_action_text;            
    }
}
