using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationController : MonoBehaviour {


    public List<string> DialogOptionsPositive = new List<string>();
    public List<string> DialogOptionsNegative = new List<string>();
    public List<Sprite> sprites = new List<Sprite>();
    public string activeDialogOptionPositive;
    public string activeDialogOptionNegative;
    private Sprite activeDialogSprite;
    public string inputString = "";
    private int currentNumDialogs = -1;
    public int maxDialogs = 0;
    

    // Use this for initialization
    void Start () {
        PickOptions();
	}
	
	// Update is called once per frame
	void Update () {
        inputString += Input.inputString;

        if (CheckIfDone(inputString))
        {
            return;
        }

        inputString = CheckIfInOptions(inputString);

        // handle clicking backspace
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            
            if (!string.IsNullOrEmpty(inputString) && inputString.Length >= 1)
            {
                if (inputString.Length == 1)
                {
                    inputString = "";
                }
                else {
                    inputString = inputString.Remove(inputString.Length - 2);
                }
                // Debug.Log(inputString);
            }
        }
    }


    private string CheckIfInOptions(string inputString)
    {
        if (!string.IsNullOrEmpty(inputString) && inputString.Length >= 1 && !Input.GetKeyDown(KeyCode.Backspace))
        {
            if (!activeDialogOptionPositive.Contains(inputString) && !activeDialogOptionNegative.Contains(inputString))
            {
                Debug.Log("WRONG");
                Debug.Log(inputString + " " + activeDialogOptionPositive + " or " + activeDialogOptionNegative);
                if (inputString.Length == 1)
                {
                    return "";
                }
                else
                {
                    return inputString.Remove(inputString.Length - 2);
                }
            }
        }
        return inputString;
    }

    private bool CheckIfDone(string inputString)
    {
        // if the inputString is exactly equal to the option, print out a success message.
        if (inputString.Equals(activeDialogOptionPositive, System.StringComparison.CurrentCultureIgnoreCase))
        {
            Debug.Log("Happy Go Lucky");
            inputString = "";
            PickOptions();
            // call the flowchart say function
            return true;
        }
        else if (inputString == activeDialogOptionNegative)
        {
            Debug.Log("Debby Downer");
            inputString = "";
            PickOptions();
            // call the flowchart say function
            return true;
        }

        return false;
    }

    void PickOptions() {

        var x = UnityEngine.Random.Range(0, DialogOptionsPositive.Count);
        activeDialogOptionPositive = DialogOptionsPositive[x];
        DialogOptionsPositive.Remove(activeDialogOptionPositive);

        var y = UnityEngine.Random.Range(0, DialogOptionsNegative.Count);
        activeDialogOptionNegative = DialogOptionsNegative[y];
        DialogOptionsNegative.Remove(activeDialogOptionNegative);

        activeDialogSprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];

        currentNumDialogs++;
    }

}
