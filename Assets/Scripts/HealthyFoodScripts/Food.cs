using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public Sprite foodImage;
    public Sprite eatenFoodImage;
    public bool healthy;
    public bool isEaten;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = foodImage;
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnMouseUp()
    {
        Debug.Log("I have been clicked!");
        GetComponent<SpriteRenderer>().sprite = eatenFoodImage;
        isEaten = true;
    }
}
