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

    private void Awake () {
        for(int i = 0; i < inventory.Length; i++) {
            inventory[i] = new ItemPlace ();
        }
    }

    private void Update () {
        for(int i = 0; i < inventory.Length; i++) {
            itemIcons[i].sprite = inventory[i].num > 0 ? items.items[inventory[i].id].icon : emptySprite;
            itemNumberLabels[i].text = inventory[i].num > 0 ? "" + inventory[i].num : "";
        }   
    }

    public void AddItem (int itemID) {
        for(int i = 0; i < inventory.Length; i++) {
            if(inventory[i].id == -1 || inventory[i].id == itemID) {
                inventory[i].id = itemID;
                inventory[i].num++;
                break;
            }
        }
    }
}

public class ItemPlace {
    public int id = -1;
    public int num = 0;
}

