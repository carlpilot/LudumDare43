using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemScriptableObject : ScriptableObject {
    public Item[] items;
}

[System.Serializable]
public class Item {
    public string name;
    public int id;
    public Sprite icon;
}
