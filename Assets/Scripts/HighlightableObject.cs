using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightableObject : MonoBehaviour {

    public Material highlightedMaterial;
    private Material[] materials;

    public bool isHighlighted;

	void Awake () {
        materials = GetComponent<MeshRenderer> ().sharedMaterials;
	}
	
	void Update () {
		if(isHighlighted) {
            Material[] m2 = new Material[GetComponent<MeshRenderer> ().sharedMaterials.Length];
            for(int i = 0; i < GetComponent<MeshRenderer> ().sharedMaterials.Length; i++) {
                m2[i] = highlightedMaterial;
            }
            GetComponent<MeshRenderer> ().sharedMaterials = m2;
        } else {
            GetComponent<MeshRenderer> ().sharedMaterials = materials;
        }
	}
}
