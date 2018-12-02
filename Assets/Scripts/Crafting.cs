using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Crafting : MonoBehaviour {

    public bool isCrafting = false;
    public GameObject craftingGrid;
    public KeyCode craftKey = KeyCode.C;
    public UIInventory inventory;

    public CraftingGridItem[] grid;

    int firstClick = -1;
    int secondClick = -1;

    private void LateUpdate () {
        if(Input.GetKeyDown(craftKey)) {
            ToggleCrafting ();
        }
        GameObject.Find ("Player").GetComponent<RigidbodyFirstPersonController> ().enabled = !isCrafting;

        if (isCrafting) {
            craftingGrid.SetActive (true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else {
            craftingGrid.SetActive (false);
        }

        if(firstClick != -1 && secondClick != -1) {
            PlaceItemInGrid ();
        }
    }

    public void ToggleCrafting () {
        isCrafting = !isCrafting;
        InvalidateClicks ();
        if(!isCrafting) {
            for(int i = 0; i < grid.Length; i++) {
                inventory.AddItem (grid[i].id);
                grid[i].id = -1;
                grid[i].icon = GameObject.Find ("Inventory").GetComponent<UIInventory> ().emptySprite;
            }
        }
    }

    public void RegisterFirstClick (int x) {
        firstClick = x;
    }

    public void RegisterSecondClick (int y) {
        secondClick = y;
    }

    public void PlaceItemInGrid () {
        if (inventory.inventory[firstClick].num == 0 || inventory.inventory[firstClick].id == -1) {
            InvalidateClicks ();
            return;
        }
        if (grid[secondClick].id != -1)
            inventory.AddItem (grid[secondClick].id);
        grid[secondClick].id = inventory.inventory[firstClick].id;
        grid[secondClick].icon = inventory.items.items[grid[secondClick].id].icon;
        inventory.inventory[firstClick].num--;

        print (firstClick + "," + secondClick);
        print (inventory.inventory[firstClick].num);

        InvalidateClicks ();
    }

    public void InvalidateClicks () {
        firstClick = -1;
        secondClick = -1;
    }
}
