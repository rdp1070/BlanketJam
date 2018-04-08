using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;

    public Text theDialog;
    public Text theSpeaker;

    public TextAsset textFile;
    public string[] textLines;
    public int currentLine, endAtLine;
    public bool isOver;

    public ChoiceController[] choices;

    public GameObject player;

    private void Start()
    {

        player = FindObjectOfType<GameObject>();

        if (textFile != null)
        {
            Debug.Log(textFile.text);
            textLines = (textFile.text.Split('\n'));

        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

    }

    private void Update()
    {
        if (choices == null || choices.Length <= 0)
        {
            // parse the line, then progress to the next one.
            ParseLine();
            if (textBox.activeInHierarchy == true && Input.GetButtonDown("Action"))
            {
                if (currentLine < endAtLine)
                {
                    currentLine++;
                }
                else
                {
                    isOver = true;
                    DisableTextBox();
                }
            }
        }
        else
        {
            ShowChoices(choices);

            if (Input.GetButtonUp("cancel")) {
                DisableTextBox();
            }
        }

    }

    private void ParseLine()
    {
        var cur = textLines[currentLine];
        if (cur.Contains(":") == false)
        {
            theSpeaker.text = "Unkown";
            theDialog.text = cur;
        }
        else
        {
            theSpeaker.text = cur.Substring(0, cur.IndexOf(':'));
            theDialog.text = cur.Substring(cur.IndexOf(':') + 1);
        }
    }

    public void ShowChoices(ChoiceController[] choices)
    {
        theDialog.enabled = false;
        theSpeaker.enabled = false;
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.gameObject.SetActive(true);
        }
    }
    public void HideChoices(ChoiceController[] choices)
    {
        theDialog.enabled = true;
        theSpeaker.enabled = true;
        
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.gameObject.SetActive(false);
        }
    }

    public void SetChoices(ChoiceController[] choices)
    {
        foreach (ChoiceController c in choices)
        {
            var butt = Instantiate<Button>(c.choicePrefab);
            butt.GetComponentInChildren<Text>().text = c.option_name;
            butt.transform.SetParent(textBox.transform);


            //if (Application.CanStreamedLevelBeLoaded(c.scene_name))
            //{
                butt.onClick.AddListener(c.SelectChoice);
            //} else {
            //    butt.interactable = false;
            //}
        }
    }


    public void SelectChoice(ChoiceController c)
    {
        DisableTextBox();
        c.SelectChoice();
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
    }

    public bool CheckIfOver()
    {
        return isOver;
    }

}
