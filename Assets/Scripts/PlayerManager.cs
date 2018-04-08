using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerManager : MonoBehaviour {

    public PlayerController player;
    public bool canMove;
    public string state;

	// Use this for initialization
	void Start () {
        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SetState(string _state = "default") {

        switch (_state)
        {
            default:
                player.canMove = true;
                break;
            case "dialog":
                player.canMove = false;
                break;
            case "minigame":
                break;
        }

    }

}
