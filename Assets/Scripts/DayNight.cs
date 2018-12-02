using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

    public float dayLengthSeconds;
    public float time = 0;

	void Update () {
        transform.Rotate (Vector3.right, 360f * Time.deltaTime / dayLengthSeconds);
        time += Time.deltaTime * 2f / dayLengthSeconds; // 0-2
	}
}
