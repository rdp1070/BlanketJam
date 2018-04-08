using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceController : MonoBehaviour {

    public string option_name, scene_name;

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
