using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechCollector : MonoBehaviour
{

    public List<Fungus.SayDialog> sayDialogs;
    public Camera camera;
    public float dialogMargin;

    // Use this for initialization
    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if active dialog is off camera, move to just on camera.
        foreach (Fungus.SayDialog dialog in sayDialogs)
        {
            if (dialog != null)
            {
                // if the character is off screen move the dialog box to the edge
                if (dialog.SpeakingCharacter.transform.position.x < (Camera.main.transform.position.x - Camera.main.orthographicSize))
                {
                    // this is to the left
                    dialog.transform.position = new Vector3(Camera.main.transform.position.x - Camera.main.orthographicSize + dialogMargin,
                        dialog.transform.position.y);

                }
                // if the character is off screen move the dialog box to the edge
                else if (dialog.SpeakingCharacter.transform.position.x > (Camera.main.transform.position.x + Camera.main.orthographicSize))
                {
                    // this is to the right
                    dialog.transform.position = new Vector3(Camera.main.transform.position.x + Camera.main.orthographicSize - dialogMargin,
                        dialog.transform.position.y);
                }
                // if the character is on screen move the dialog box to above them.
                else
                {
                    // on screen with character, move to the character.
                    dialog.transform.position =
                        new Vector3(dialog.SpeakingCharacter.transform.position.x, dialog.transform.position.y + dialogMargin);
                }
            }
        }
    }
}
