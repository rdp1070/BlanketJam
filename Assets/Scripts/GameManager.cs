using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextBoxManager[] textBoxManagers;
    public PlayerManager playerManager;
    public InteractableManager interactableManager;

    public int time_of_day;
    private int max_time = 3;

    // Update is called once per frame
    void Update()
    {
        //if (interactableManager.CheckForInteracting() == true ) {
        //    playerManager.SetState("dialog");
        //    textBoxManager.textBox.SetActive(true);
        //} else if (interactableManager.CheckForInteracting() == false) {
        //    playerManager.SetState();
        //    textBoxManager.textBox.SetActive(false);
        //}
    }
    private void Awake()
    {
        time_of_day = 0; 
    }

    void Passtime() {
        if (time_of_day < max_time) {
            time_of_day++;
        }
        else {
            time_of_day = 0;
        }
    }
}

