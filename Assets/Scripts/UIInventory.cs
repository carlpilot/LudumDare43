using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour {

    public ItemScriptableObject items;
    public Sprite emptySprite;
    public ItemPlace[] inventory = new ItemPlace[6];

    public Image[] itemIcons;
    public Text[] itemNumberLabels;

    public RectTransform arrow;
    Vector2 arrowStart;
    public int selectedItem = 0;

    private void Awake () {
        arrowStart = arrow.anchoredPosition;
        for(int i = 0; i < inventory.Length; i++) {
            inventory[i] = new ItemPlace ();
        }
    }

    private void Update () {
        for(int i = 0; i < inventory.Length; i++) {
            itemIcons[i].sprite = (inventory[i].num > 0 && inventory[i].id != -1) ? items.items[inventory[i].id].icon : emptySprite;
            itemNumberLabels[i].text = inventory[i].num > 0 ? "" + inventory[i].num : "";
        }

        selectedItem = (int) (((float) selectedItem + -Input.GetAxis ("Mouse ScrollWheel") * 10) % inventory.Length);
        if (selectedItem < 0) selectedItem = inventory.Length - 1;
        arrow.anchoredPosition = arrowStart + Vector2.down * (int)selectedItem * 75;

        if (Input.GetKeyDown (KeyCode.Q)) {
            DropItem (inventory[selectedItem].id);
        }
    }

    bool isItemAvailable (int itemID) {
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i].id == itemID && inventory[i].num > 0) return true;
        }
        return false;
    }

    void DropItem (int itemID) {
        if (!isItemAvailable (itemID)) return;
        RemoveItem (itemID);
        Instantiate (items.items[itemID].prefab, Camera.main.transform.position + Camera.main.transform.forward * 1.5f, items.items[itemID].prefab.transform.rotation);
    }

    public void AddItem (int itemID) {
        if (itemID < 0) return;
        for(int i = 0; i < inventory.Length; i++) {
            if(inventory[i].id == itemID) {
                inventory[i].id = itemID;
                inventory[i].num++;
                return;
            }
        }
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i].id == -1 || inventory[i].num <= 0) {
                inventory[i].id = itemID;
                inventory[i].num++;
                return;
            }
        }
    }

    public void RemoveItem (int itemID) {
        for(int i = 0; i < inventory.Length; i++) {
            if(inventory[i].id == itemID) {
                inventory[i].num -= 1;
                return;
            }
        }
    }
}

public class ItemPlace {
    public int id = -1;
    public int num = 0;
}

