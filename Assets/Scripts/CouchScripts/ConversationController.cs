using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationController : MonoBehaviour
{


    public List<string> DialogOptionsPositive = new List<string>();
    public List<string> DialogOptionsNegative = new List<string>();
    public List<Sprite> sprites = new List<Sprite>();
    public string activeDialogOptionPositive { get; set; }
    public string activeDialogOptionNegative { get; set; }
    public Fungus.Flowchart flowchart;
    public UnityEngine.UI.Image ReactionImageHolder;
    private bool active = true;
    private Sprite activeDialogSprite;
    public string inputString = "";
    private int currentNumDialogs = -1;
    public int maxDialogs = 0;
    public int positivity = 0;

    // Use this for initialization
    void Start()
    {
        if (flowchart == null)
            flowchart = GetComponent<Fungus.Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (active == true)
        {
            inputString += Input.inputString;
            if (CheckIfDone(inputString))
            {
                inputString = "";
                return;
            }

            inputString = CheckIfInOptions(inputString);

            // handle clicking backspace
            if (Input.GetKeyDown(KeyCode.Backspace))
            {

                if (!string.IsNullOrEmpty(inputString))
                {
                    //Debug.Log("backspace");
                    if (inputString.Length == 1)
                    {
                        inputString = "";
                    }
                    else
                    {

                        inputString = inputString.Remove(inputString.Length - 2); // backspace is a character...

                    }

                    flowchart.SetStringVariable("inputString", inputString);
                }
            }

            // update the screen
            if (flowchart != null)
            {
                flowchart.SetStringVariable("inputString", inputString);
            }
        }
    }

    public string CheckStrangeCharacters(string option)
    {
        if (Input.anyKeyDown && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Backspace) && string.IsNullOrEmpty(Input.inputString))
        {
            if (option.Length > inputString.Length)
            {
                char special_character = option[inputString.Length];
                Debug.Log(special_character);
                Debug.Log(special_character.ToString());
                if (char.IsPunctuation(special_character) == true)
                {
                    return special_character.ToString();
                }
            }
        }

        return "";
    }

    private string CheckIfInOptions(string inputString)
    {
        if (inputString != null && inputString != "" && !Input.GetKeyDown(KeyCode.Backspace)
            && !Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.RightShift))
        {
            if (inputString.Length >= 1)
            {
                var negative_substr = activeDialogOptionNegative;
                if (activeDialogOptionNegative.Length > inputString.Length)
                {
                    negative_substr = activeDialogOptionNegative.Substring(0, inputString.Length);
                }

                var positive_substr = activeDialogOptionPositive;
                if (activeDialogOptionPositive.Length > inputString.Length)
                {
                    positive_substr = activeDialogOptionPositive.Substring(0, inputString.Length);
                }


                inputString += CheckStrangeCharacters(activeDialogOptionNegative);
                if (negative_substr.Contains(inputString))
                {
                    // set the variable in the flowchart
                    if (flowchart != null)
                    {
                        // update the boxes on the screen
                        flowchart.ExecuteIfHasBlock("Correct Negative Text");
                    }
                } // end if negative

                inputString += CheckStrangeCharacters(activeDialogOptionPositive);
                if (positive_substr.Contains(inputString))
                {

                    // set the variable in the flowchart
                    if (flowchart != null)
                    {
                        // update the boxes on the screen
                        flowchart.ExecuteIfHasBlock("Correct Positive Text");
                    }
                } // end if positive
                if (!positive_substr.Contains(inputString) && !(negative_substr.Contains(inputString)))
                {
                    Debug.Log("WRONG");
                    Debug.Log(inputString);
                    flowchart.ExecuteIfHasBlock("Shake Blocks");
                    if (inputString.Length == 1)
                    {
                        inputString = "";
                    }
                    else
                    {
                        inputString = inputString.Remove(inputString.Length - 1);
                    }
                }// end if wrong input
            }
            else
            {
                inputString = "";
            }
        } // end if not null

        return inputString; // if none of those cases (somehow) return what they gave you
    }

    public void CheckMaxDialogs() {
        if (currentNumDialogs >= maxDialogs)
        {
            // transition to the end state of the level.
            if (positivity > 0)
                flowchart.ExecuteIfHasBlock("Positive End Text");
            else
                flowchart.ExecuteIfHasBlock("Negative End Text");
        }
    }

    private bool CheckIfDone(string inputString)
    {

        CheckMaxDialogs();

        // if the inputString is exactly equal to the option, print out a success message.
        if (inputString.Equals(activeDialogOptionPositive, System.StringComparison.CurrentCultureIgnoreCase))
        {
            Debug.Log("Happy Go Lucky");
            flowchart.SetStringVariable("inputString", activeDialogOptionPositive);
            positivity++;
            flowchart.ExecuteIfHasBlock("Next Group");
            flowchart.ExecuteIfHasBlock("Positive Reacts");
            // call the flowchart say function
            return true;
        }
        else if (inputString == activeDialogOptionNegative)
        {
            Debug.Log("Debby Downer");
            flowchart.SetStringVariable("inputString", activeDialogOptionNegative);
            positivity--;
            flowchart.ExecuteIfHasBlock("Next Group");
            flowchart.ExecuteIfHasBlock("Negative Reacts");
            // call the flowchart say function
            return true;
        }

        return false;
    }

    public void ToggleActive() {
        active = !active;
    }

    public void PickOptions()
    {

        if (currentNumDialogs == maxDialogs)
        {
            // transition to the end state of the level.
            if (positivity > 0)
                flowchart.ExecuteIfHasBlock("Positive End Text");
            else
                flowchart.ExecuteIfHasBlock("Negative End Text");
            return;
        }

        var x = UnityEngine.Random.Range(0, DialogOptionsPositive.Count);
        activeDialogOptionPositive = DialogOptionsPositive[x];
        DialogOptionsPositive.Remove(activeDialogOptionPositive);

        var y = UnityEngine.Random.Range(0, DialogOptionsNegative.Count);
        activeDialogOptionNegative = DialogOptionsNegative[y];
        DialogOptionsNegative.Remove(activeDialogOptionNegative);

        activeDialogSprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];
        ReactionImageHolder.sprite = activeDialogSprite;

        flowchart.SetStringVariable("activeDialogOptionPositive", activeDialogOptionPositive);
        flowchart.SetStringVariable("activeDialogOptionNegative", activeDialogOptionNegative);

        currentNumDialogs++;
    }

}
