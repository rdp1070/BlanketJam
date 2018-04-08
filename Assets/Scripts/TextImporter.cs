using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextImporter : MonoBehaviour
{

    public TextAsset textFile;
    public string[] textLines;

    public int lineCount;
    public int currentLine = 0;

    private void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
            lineCount =  textLines.Length;
        }
    }


    public string GetCurrentLine() {
        return textLines[currentLine];
    }

    public void NextLine()
    {
        if (currentLine + 1 < lineCount)
            currentLine++;
    }
    

}
