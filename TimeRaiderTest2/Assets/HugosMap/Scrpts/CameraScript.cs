using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


	public Transform lookHere;

	Vector3 velocity = Vector3.zero;
	float smooth = 0.15f;

	public bool marioRunMode = false;
	public bool hercules = false;
	public bool marioTowerMode = false;
	public bool mazeMode;

	Vector3 targetVector;
	Vector3 pacStartPos;

	void Start ()
	{
		if (hercules || mazeMode) {
			targetVector = new Vector3 (0, 8, -7);
		} else if (marioRunMode) {
			targetVector = new Vector3 (4, 6, -22);
		} else if (marioTowerMode) {
			targetVector = new Vector3 (0, 6, -20);
		} 
			
	}


	void FixedUpdate () {

		Vector3 targetPosition = lookHere.TransformPoint (targetVector);
		

		if (hercules || marioTowerMode) {
			transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (0, targetPosition.y, targetPosition.z), ref velocity, smooth);
		} else if (marioRunMode) {
			transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smooth);
		} else {
			transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (targetPosition.x, targetPosition.y, -10), ref velocity, smooth);
		}
			
	}
}
