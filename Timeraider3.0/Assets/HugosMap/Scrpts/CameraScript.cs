using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


	public Transform lookHere;

	Vector3 velocity = Vector3.zero;
	float smooth = 0.15f;

	public bool hercules = false;

	Vector3 pacStartPos;
	public int x;
	public int y;
	public int z;

	void FixedUpdate () {




		if (!hercules) {
			Vector3 targetPosition = lookHere.TransformPoint (new Vector3 (x, y, -z));
			transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smooth);
		} else {
			Vector3 targetPositions = lookHere.TransformPoint (new Vector3 (0, 6, -22));
			transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (0, targetPositions.y, targetPositions.z), ref velocity, smooth);
		}

		// Binda kameran till teleporter och lerpa om man har direction = 2 i 2 sekunder

	}
}
