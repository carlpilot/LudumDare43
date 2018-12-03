using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highlighter : MonoBehaviour {

    public Text highlightedIdentifier;
    public GameObject WinMenu;

	void Update () {
        highlightedIdentifier.text = "";
        foreach (GameObject g in GameObject.FindGameObjectsWithTag ("Highlightable")) {
            g.GetComponent<HighlightableObject> ().isHighlighted = false;
        }
        RaycastHit hit;
	    if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 6f)) {
            Debug.Log (hit.transform.name);
            if(hit.transform.tag.Equals("Highlightable")) {
                hit.transform.GetComponent<HighlightableObject> ().isHighlighted = true;
                highlightedIdentifier.text = hit.transform.GetComponent<HighlightableObject> ().highlightText;
            }

            if (Input.GetMouseButtonUp (0) && hit.collider.GetComponent<Harvestable>() != null) {
                hit.collider.GetComponent<Harvestable> ().Harvest ();
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && highlightedIdentifier.text.Contains("Escape Vehicle")) {
            Time.timeScale = 0;
            WinMenu.SetActive (true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
