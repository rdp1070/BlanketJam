using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthyFoodGameManager : MonoBehaviour {

    public Food[] foods;
    List<Food> healthyFoods;
    List<Food> takeoutFoods;
    public bool HealthyGoal = true;
    public Fungus.Flowchart flowchart;
    
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

    public void SetHealthyGoal() {
        HealthyGoal = true;
    }

    public void SetTakeoutGoal() {
        HealthyGoal = false;
    }



	// Update is called once per frame
	void Update () {
        var remains = false;

        foreach (Food food in healthyFoods) {
            if (!food.isEaten && HealthyGoal == true) {
                remains = true;
            }
        }
        foreach (Food food in takeoutFoods)
        {
            if (!food.isEaten && HealthyGoal == false)
            {
                remains = true;
            }
        }

        if (remains == false) {
            Debug.Log("You ate em!");
            flowchart.ExecuteIfHasBlock("Scene End");
        }

	}
}
