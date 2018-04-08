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

    public ChoiceController[] choices;

    // this should have a list of "dialouge options"

	// Use this for initialization
	void Start () {
        choices = GetComponentsInChildren<ChoiceController>();
        display_Interaction = false;
        interacting = false;
	}
    
    // Update is called once per frame
    void Update () {
        
	}

    public void Display_Interaction_text(bool visible = true) {
        display_Interaction = visible;
        gameObject.SetActive(visible);
    }
}
