using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextBoxManager textBoxManager;
    public PlayerManager playerManager;
    public InteractableManager interactableManager;

    // Update is called once per frame
    void Update()
    {
        if (interactableManager.CheckForInteracting() == true) {
            playerManager.SetState("dialog");
            textBoxManager.textBox.SetActive(true);
        } else if (interactableManager.CheckForInteracting() == false) {
            playerManager.SetState();
            textBoxManager.textBox.SetActive(false);
        }
    }
}

