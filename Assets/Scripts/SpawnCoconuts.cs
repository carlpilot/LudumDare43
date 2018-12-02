using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoconuts : MonoBehaviour {

    public float avgTimeBetweenCoconutsSeconds;

    public Transform CoconutSpawningPointParent;

    public GameObject coconutPrefab;

    Vector3[] spawnpoints;

    private void Awake () {
        spawnpoints = new Vector3[CoconutSpawningPointParent.childCount];
        for (int i = 0; i < CoconutSpawningPointParent.childCount; i++) {
            spawnpoints[i] = CoconutSpawningPointParent.GetChild (i).position;
        }
    }

    void Update () {
		if(Random.Range(0f, avgTimeBetweenCoconutsSeconds) < Time.deltaTime) {
            Instantiate (coconutPrefab, spawnpoints[Random.Range (0, spawnpoints.Length)], Quaternion.identity);
        }
	}
}
