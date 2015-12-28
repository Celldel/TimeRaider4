using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


	public Transform lookHere;

	Vector3 velocity = Vector3.zero;
	float smooth = 0.15f;

	public bool hercules = false;

	Vector3 pacStartPos;


	void FixedUpdate () {


		Vector3 targetPosition = lookHere.TransformPoint (new Vector3 (0, 5, -7));

		if (!hercules) {
			transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (targetPosition.x, targetPosition.y, -10), ref velocity, smooth);
		} else {
			transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (0, targetPosition.y, targetPosition.z), ref velocity, smooth);
		}
			
		// Binda kameran till teleporter och lerpa om man har direction = 2 i 2 sekunder

	}
}
