using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Survival : MonoBehaviour {

    public float health = 1;
    public float food = 1;
    public float water = 1;

    public Image healthIndicator;
    public Text healthText;
    public Image foodIndicator;
    public Text foodText;
    public Image waterIndicator;
    public Text waterText;

    [Space]
    public float timeForFoodToDepleteCompletely;
    public float timeForWaterToDepleteCompletely;
    public float foodPenaltyPerSecond;
    public float waterPenaltyPerSecond;

    [Space]
    public GameObject gameOver;

	void Update () {
        if(food > 0)
            food -= Time.deltaTime / timeForFoodToDepleteCompletely;
        if(water > 0)
            water -= Time.deltaTime / timeForWaterToDepleteCompletely;
        if(food <= 0)
            health -= foodPenaltyPerSecond * Time.deltaTime;
        if (water <= 0)
            health -= waterPenaltyPerSecond * Time.deltaTime;
        if(health < 0) {
            health = 0;
            Die ();
        }
        UpdateDisplay ();
	}

    void Die () {
        Time.timeScale = 0;
        gameOver.SetActive (true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void UpdateDisplay () {
        healthIndicator.fillAmount = health;
        healthText.text = Mathf.RoundToInt (health * 100) + "%";
        foodIndicator.fillAmount = food;
        foodText.text = Mathf.RoundToInt (food * 100) + "%";
        waterIndicator.fillAmount = water;
        waterText.text = Mathf.RoundToInt (water * 100) + "%";
    }
}
