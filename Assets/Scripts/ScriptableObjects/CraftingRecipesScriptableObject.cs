using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CraftingRecipesScriptableObject : ScriptableObject {
    public CraftingRecipe[] recipes;
}

[System.Serializable]
public class CraftingRecipe {
    public string Name;
    public Vector2 topRow;
    public Vector2 bottomRow;
    public int result;
}
