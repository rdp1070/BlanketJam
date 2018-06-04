using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeObstacleController : ClickableObject {

    public int layer; // set before running
    //public int depth;  //implement later.

    //public GameObject Manager;

    protected int currentLane; // determined by Manager
    public int width; // how many lanes wide 
    public int height; // how many sections tall.

    public SpriteRenderer spriteRenderer;


    public FridgeObstacleController( Sprite _sprite, int layer = 1, int width = 1, int height =1) {

        this.layer = layer;
        this.width = width;
        this.height = height;

        spriteRenderer = new SpriteRenderer()
        {
            sprite = _sprite
        };
    }

	// Use this for initialization
	void Start () {

        if (width < 1) {
            width = 1;
        }

        if (height < 1)
        {
            height = 1;
        }

        if (layer < 1)
        {
            layer = 1;
        }

    }
}
