using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthyFoodGameManager : MonoBehaviour {

    public Food[] foods;
    List<Food> healthyFoods;
    public TextBoxManager TextBoxManager;
    
	// Use this for initialization
	void Start () {



        foods = GetComponentsInChildren<Food>();
        healthyFoods = new List<Food>();
        foreach (Food food in foods) {
            if (food.healthy) {
                healthyFoods.Add(food);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        var remains = false;

        foreach (Food food in healthyFoods) {
            if (!food.isEaten) {
                remains = true;
            }
        }

        if (remains == false) {
            Debug.Log("You ate em!");
            SceneSegue();
        }

	}

    private void SceneSegue() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FinalScene", LoadSceneMode.Single);
    }
}
