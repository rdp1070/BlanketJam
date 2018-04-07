using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool isTalking;
    public bool canMove;
    public string state;
    public GameObject Player { get; set; }

    // Use this for initialization
    void Start()
    {
        isTalking = false;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isTalking == true)
        {
            canMove = false;
        }

    }
}
