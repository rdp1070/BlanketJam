using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FridgeGameManager : SinkManager {

    public Food[] foods;

    public List<FridgeObstacleController> Obstacles;
    List<Layer> Layers;

    public GameObject BoundingBox;
    public int numLayers;
    public int numLanes;

    public Sprite defaultSprite;

    public Color DarkestColor = new Color(55, 55, 55);

    public class Layer {
        public List<bool> lanes;

        public Layer(int numLanes) {
            lanes = new List<bool>(numLanes);
            for (int i = 0; i < numLanes; i++) {
                lanes.Add(false);
            }
        }
    }

    // Use this for initialization
    void Start () {
        Layers = new List<Layer>();
        foods = GetComponentsInChildren<Food>(); // get all the food on startup

        Obstacles = GetComponentsInChildren<FridgeObstacleController>().ToList(); // this gets a list of obstacles you set up in the scene at complie time.
        numLayers = Obstacles.OrderByDescending(item => item.layer).FirstOrDefault().layer; // this gets the layer that is the furthest back

        ApplyObstacleShading();

        for (int i = 0; i < numLayers; i++)
        {
            Layers.Add(new Layer(numLanes));
        }
	}


    /// <summary>
    /// Shade obstacle based on depth of fridge. 
    /// Furthest back obstacles are the darkest.
    /// </summary>
    [ContextMenu("Refresh Shading of obstacles.")]
    public void ApplyObstacleShading() {
        foreach (FridgeObstacleController obstacle in Obstacles)
        {
            var color_val = (1 - DarkestColor.r) / numLayers;
            var current_color = 1 - (color_val * obstacle.layer); // white minus portion of darkness determined by how far back in the fridge it is.
            obstacle.spriteRenderer.sortingOrder = numLayers - obstacle.layer + 1; // put darker obstacles in the back of the fridge.
            obstacle.spriteRenderer.color = new Color(current_color, current_color, current_color); // set the color.
        }
    }

    /// <summary>
    /// Make a new Obstacle
    /// </summary>
    /// <returns> Takese in nothing and just returns a New Obstacle with default values.</returns>
    FridgeObstacleController GenerateNewObstacle(){

        // return a new obstacle, in the future we can pass in more,
        // or add different functionality here, but this is all we need for now.
        return new FridgeObstacleController(defaultSprite, 1, 1,1);
    }

    // Update is called once per frame
    void Update()
    {
        worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
        worldPoint.z = 0;
        worldPoint.y = Mathf.Clamp(worldPoint.y, minHeight, maxHeight);
        cursorJoint.gameObject.transform.position = worldPoint;

        if (Input.GetMouseButtonDown(0))
        {
            TryPickupObject();
        }
        else if (Input.GetMouseButtonUp(0) && activeObject != null)
        {
            ReleaseObject();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        ClickableObject test = other.gameObject.GetComponent<ClickableObject>();
        if (test != null)
        {
            obstructions++;
            Debug.Log("Stuff in the fridge: " + obstructions);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ClickableObject test = other.gameObject.GetComponent<ClickableObject>();
        if (test != null)
        {
            obstructions--;
            Debug.Log("Stuff in the fridge: " + obstructions);
            if (obstructions <= 0 && positiveAction == false)
            {
                Debug.Log("fridge is clear.");
            }
        }
    }

    [ContextMenu("End Scene Manually")]
    void EndScene() {
        Debug.Log("You ate em!");
        flowChart.ExecuteIfHasBlock("Scene End");        
    }
}
