using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FianlSceneManager : MonoBehaviour {

    Image[] images;
    GameObject imageBox;
    public Image Panel;
    public TextImporter TextImporter;
    public Text Textbox;
	// Use this for initialization
	void Start () {
        images = GetComponentsInChildren<Image>();
        foreach (Image i in images) {
            i.gameObject.SetActive( false);
        }
        images[0].gameObject.SetActive(true);
        Panel.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        Textbox.text = TextImporter.GetCurrentLine();
	}

    private void OnMouseUp()
    {
        Debug.Log("This has been clicked.");
        TextImporter.NextLine();
    }

}
