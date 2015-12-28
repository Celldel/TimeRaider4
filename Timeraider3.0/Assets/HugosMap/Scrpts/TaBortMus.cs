using UnityEngine;
using System.Collections;

public class TaBortMus : MonoBehaviour {



	void Start () {
		Cursor.visible = false;
	}

	void SetCrusorLock(bool isLocked){



	}
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.K)){
			Cursor.visible = false;
		}
		if (Input.GetKeyDown (KeyCode.L)){
			Cursor.visible = true;
		}
	}
}
