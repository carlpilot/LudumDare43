using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvestable : MonoBehaviour {

    public int ItemID;

    public void Harvest () {
        GameObject.Find ("Inventory").GetComponent<UIInventory> ().AddItem (ItemID);
        Destroy (this.gameObject);
    }
}
