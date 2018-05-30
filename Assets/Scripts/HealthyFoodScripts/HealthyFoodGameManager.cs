using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthyFoodGameManager : SinkManager {

    public Food[] foods;
    List<Food> healthyFoods;
    List<Food> takeoutFoods;
    public Fungus.Flowchart flowchart;

    private List<GameObject> plateSlot = new List<GameObject>();
    bool objectHeld;
    Vector3 worldPoint = Vector3.zero;

    private bool isChecking = false;

    // Use this for initialization
    void Start () {

        foods = GetComponentsInChildren<Food>();
        healthyFoods = new List<Food>();
        takeoutFoods = new List<Food>();

        foreach (Food food in foods) {
            if (food.healthy)
            {
                healthyFoods.Add(food);
            }
            else {
                takeoutFoods.Add(food);
            }
        }
	}

    // Update is called once per frame
    void Update()
    {
        worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
        worldPoint.z = 0;
        worldPoint.y = Mathf.Clamp(worldPoint.y, minHeight, maxHeight);
        cursorJoint.gameObject.transform.position = worldPoint;

        if (isChecking) {
            CheckIfGameEnd();
        }

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
            Debug.Log("Stuff in the sink: " + obstructions);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ClickableObject test = other.gameObject.GetComponent<ClickableObject>();
        if (test != null)
        {
            obstructions--;
            Debug.Log("Stuff in the sink: " + obstructions);
            if (obstructions <= 0 && positiveAction == false)
            {
                Debug.Log("Sink is clear.");
            }
        }
    }


    public void ToggleIsChecking() {
        isChecking = !isChecking;
    }

    void CheckIfGameEnd() {
        var remains = false;

        foreach (Food food in healthyFoods)
        {
            if (!food.isEaten && positiveAction == true)
            {
                remains = true;
                break;
            }
        }
        foreach (Food food in takeoutFoods)
        {
            if (!food.isEaten && positiveAction == false)
            {
                remains = true;
                break;
            }
        }

        if (remains == false)
        {
            Debug.Log("You ate em!");
            flowchart.ExecuteIfHasBlock("Scene End");
            ToggleIsChecking();
        }
    }
}
