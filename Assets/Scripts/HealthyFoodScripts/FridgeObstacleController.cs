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
        gameObject.layer = layer; 
        this.width = width;
        this.height = height;

        spriteRenderer = new SpriteRenderer()
        {
            sprite = _sprite
        };
    }

	// Use this for initialization
	void Start () {
        gameObject.layer = layer;
        if (width < 1) {
            width = 1;
        }

        if (height < 1)
        {
            height = 1;
        }

        if (layer < 0)
        {
            layer = 0;
        }

    }

    public void OnMouseUp()
    {
        Debug.Log("Interception.");
    }

    public void OnMouseEnter()
    {
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Mouse down when entering.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        //Debug.Log(collision.gameObject.name + "'s Layer: " + collision.gameObject.layer + System.Environment.NewLine 
        //    + gameObject.name +"CurrentObject's Layer: " + gameObject.layer);

        try
        {
            var collision_layer = collision.gameObject.GetComponent<FridgeObstacleController>().layer;
            Debug.Log(collision_layer);
            if (collision_layer != this.layer)
            {
                Physics2D.IgnoreCollision(collider, collision.collider);
            }
        }
        catch (System.Exception ex)
        {
            // collide as normal.
            //Debug.Log(ex);
        }
    }
}
