using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextImporter : MonoBehaviour
{

    public TextAsset textFile;
    public string[] textLines;

    private void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));

        }
    }

}
