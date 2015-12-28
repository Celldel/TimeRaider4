using UnityEngine;
using System.Collections;

public class FallTrigger : MonoBehaviour {

	public FallingObstacle FO;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player" && FO != null) {
			FO.Invoke ("Release", 0);
		}
	}
}
