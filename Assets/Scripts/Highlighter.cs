using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour {

	void Update () {
        RaycastHit hit;
	    if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10f)) {
            Debug.Log (hit.transform.name);
            if(hit.transform.tag.Equals("Highlightable")) {
                hit.transform.GetComponent<HighlightableObject> ().isHighlighted = true;
            }
        }
        foreach (GameObject g in GameObject.FindGameObjectsWithTag ("Highlightable")) {
            if (hit.transform != null && g != hit.transform.gameObject) {
                g.GetComponent<HighlightableObject> ().isHighlighted = false;
            }
        }
    }
}
