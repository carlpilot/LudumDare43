using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingGridItem : MonoBehaviour {

    public int id = -1;
    public Sprite icon;

    Image image;

    private void Start () {
        GameObject g = new GameObject ("Icon");
        g.AddComponent<RectTransform> ();
        g.GetComponent<RectTransform> ().SetParent (transform);
        g.GetComponent<RectTransform> ().localPosition = Vector2.zero;
        g.GetComponent<RectTransform> ().sizeDelta = GetComponent<RectTransform>().sizeDelta;
        g.AddComponent<Image> ().sprite = GameObject.Find ("Inventory").GetComponent<UIInventory> ().emptySprite;
        image = g.GetComponent<Image> ();
    }

    void Update () {
        if (icon != null)
            image.sprite = icon;
        else image.sprite = GameObject.Find ("Inventory").GetComponent<UIInventory> ().emptySprite;
	}
}
