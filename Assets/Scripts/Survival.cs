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
    public float healthRegenPerSecond = 0.02f;
    public float foodThresholdToRegenerate = 0.8f;
    public float waterThresholdToRegenerate = 0.8f;
    public float foodRegenPenaltyPerSecond = 0.02f;
    public float waterRegenPenaltyPerSecond = 0.01f;

    [Space]
    public GameObject gameOver;
    public Text causeOfDeath;

    [Space]
    public UIInventory inventory;

    [Space]
    public KeyCode eatKeyCode = KeyCode.E;

	void Update () {

        if (Input.GetKeyDown (eatKeyCode)) {
            bool successful = false;
            if (inventory.items.items[inventory.inventory[inventory.selectedItem].id].foodValue > 0 && inventory.inventory[inventory.selectedItem].num > 0) {
                successful = true;
                food = Mathf.Clamp01 (food + inventory.items.items[inventory.inventory[inventory.selectedItem].id].foodValue);
            }
            if (inventory.items.items[inventory.inventory[inventory.selectedItem].id].waterValue > 0 && inventory.inventory[inventory.selectedItem].num > 0) {
                successful = true;
                water = Mathf.Clamp01 (water + inventory.items.items[inventory.inventory[inventory.selectedItem].id].waterValue);
            }

            if (successful) inventory.inventory[inventory.selectedItem].num -= 1;
        }

        if(health <= 1 && food >= foodThresholdToRegenerate && water >= waterThresholdToRegenerate) {
            health += Time.deltaTime * healthRegenPerSecond;
            food -= Time.deltaTime * foodRegenPenaltyPerSecond;
            water -= Time.deltaTime * waterRegenPenaltyPerSecond;
        }

        if (food > 0)
            food -= Time.deltaTime / timeForFoodToDepleteCompletely;
        if(water > 0)
            water -= Time.deltaTime / timeForWaterToDepleteCompletely;
        if(food <= 0)
            health -= foodPenaltyPerSecond * Time.deltaTime;
        if (water <= 0)
            health -= waterPenaltyPerSecond * Time.deltaTime;
        if(health <= 0) {
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
        if (water <= 0) causeOfDeath.text = "You died of dehydration.";
        else if (food <= 0) causeOfDeath.text = "You died of starvation.";
        else causeOfDeath.text = "You died.";
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
