using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceController : MonoBehaviour {

    public string introText, outroText, sceneName;
    public TextBoxManager textBoxManager;

    private void Start()
    {
        if (textBoxManager == null) {
            textBoxManager = FindObjectOfType<TextBoxManager>();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SelectChoice()
    {
    }
}
