using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theDialog;
    public Text theSpeaker;

    public TextAsset textFile;
    public string[] textLines;
    public int currentLine, endAtLine;

    public GameObject player;

    private void Start()
    {

        player = FindObjectOfType<GameObject>();

        if (textFile != null)
        {
            Debug.Log(textFile.text);
            textLines = (textFile.text.Split('\n'));

        }

        if (endAtLine == 0) {
            endAtLine = textLines.Length - 1;
        }

    }

    private void Update()
    {
        // parse the line, then progress to the next one.
        ParseLine();
        if ( textBox.activeInHierarchy == true && Input.GetButtonDown("Action"))
        {
            if (currentLine < endAtLine ) {
                currentLine++;
            }
            else
            {
                DisableTextBox();
            }
        }
        
    }

    private void ParseLine() {
        var cur = textLines[currentLine];
        Debug.Log(cur);
        if (cur.Contains(":") == false)
        {
            theSpeaker.text = "Unkown";
            theDialog.text = cur;
        }
        else
        {
            theSpeaker.text = cur.Substring(0, cur.IndexOf(':'));
            theDialog.text = cur.Substring(cur.IndexOf(':')+1);
        }
    }


    public void EnableTextBox() {
        textBox.SetActive(true);
    }

    public void DisableTextBox() {
        textBox.SetActive(false);
    }

}
