using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PacCollisions : MonoBehaviour {

	public GameObject[] teleports;
	public GameBrain GB;


	// Use this for initialization
	void Start () {

		GB = GameObject.Find ("GameBrain").GetComponent<GameBrain> ();

		if (teleports.Length != 0) {
			for (int i = 0; i < GB.lastLevel + 1; i++) {
				teleports [i].tag = "teleporter";
			}
		}
	}
		

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "pellet")
		{
			other.gameObject.SetActive (false);
		}

		if (other.gameObject.tag == "SuperPellet") {
			GB.Invoke ("GainArmour", 0);
			Destroy (other.gameObject);
		}

		// Teleporters sätts in i inspektorn och sedan byter pacman level utefter.
		if (other.gameObject.tag == "teleporter")
		{
			for (int i = 0; i < teleports.Length; i++) {
				if (other.gameObject == teleports [i]) {
					SceneManager.LoadScene (i + 1);
				}
			}
		}


		if (other.gameObject.tag == "Enemy") {

			if (GB.armoured) {
				GB.Invoke ("LoseArmour", 0);
				Debug.Log ("I was hit with armour");

			} else {
				GB.Invoke ("LoseLife", 0);
				GB.Invoke ("SetDeadPellet", 0);
			}

		} 


		//SetDeadPellet byter även nivå tillbaka till originalnivån.
		if (other.gameObject.tag == "Key") {

			GB.Invoke ("SetDeadPellet", 0);
		}
	}
}
