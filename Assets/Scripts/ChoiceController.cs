using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceController : MonoBehaviour {

    public string option_name, scene_name;
    public Button choicePrefab;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SelectChoice()
    {
        new MenuManager().GotoScene(scene_name);
    }
}
