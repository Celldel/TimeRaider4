using UnityEngine;
using System.Collections;

public class MainRoomMovement : MonoBehaviour {

	int speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {

		if (Input.GetKey (KeyCode.Space)){
			transform.Translate (Vector3.up *Time.deltaTime * speed);
		}

		if (Input.GetKey (KeyCode.W)) { 

			transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}
		else if (Input.GetKey (KeyCode.S)) {

			transform.Translate (Vector3.back * Time.deltaTime * speed);
		}

		if (Input.GetKey (KeyCode.A)) {

			transform.Translate (Vector3.left * Time.deltaTime * speed);
		}
		else if (Input.GetKey (KeyCode.D)) {

			transform.Translate (Vector3.right * Time.deltaTime * speed);
		}

	}
}
