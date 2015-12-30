﻿using UnityEngine;
using System.Collections;

public class HuntTrigger : MonoBehaviour {

	public EnemyMovement EM;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			EM.InvokeRepeating ("HuntPacman", 0, 1);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player"){
			EM.CancelInvoke("HuntPacman");
			EM.Invoke ("Patrol", 0);
		}
	}
}
