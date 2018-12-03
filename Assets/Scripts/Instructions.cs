using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

    public GameObject instructions;

	public void ToggleInstructions () {
        instructions.SetActive (!instructions.activeSelf);
    }
}
