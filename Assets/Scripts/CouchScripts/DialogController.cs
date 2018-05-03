using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour {

    public Sprite response_sprite;
    public string option_A;
    public string option_B;

	// Use this for initialization
	void Start () {
        if (option_A == null) {
            option_A = "";
        }
        option_A = option_A ?? "";
        option_B = option_B ?? "";
	}
}
