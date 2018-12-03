using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadPlant : MonoBehaviour {

    public float avgTimeBetweenSpreading = 180f;

	void Update () {
		if(Random.Range(0, avgTimeBetweenSpreading / Time.deltaTime) <= 1) {
            RaycastHit hit;
            if (Physics.Raycast (transform.position + Vector3.forward * Random.Range (-3f, 3f) + Vector3.right * Random.Range (-3f, 3f) + Vector3.up * 2f, Vector3.down, out hit)) {
                if(hit.collider.tag == "Island" && hit.point.y > 1f && Physics.OverlapSphere(hit.point, 5f).Length < 15) {
                    Instantiate (this.gameObject, hit.point, transform.rotation);
                }
            }
        }
	}
}
