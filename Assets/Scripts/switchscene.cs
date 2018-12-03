using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchscene : MonoBehaviour {

	public void Scene (string name) {
        UnityEngine.SceneManagement.SceneManager.LoadScene (name);
    }

    public void Quit () {
        Application.Quit ();
    }
}
