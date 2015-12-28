using UnityEngine;
using System.Collections;

public class FallingObstacle : MonoBehaviour {

	Rigidbody rb;
	public MoveBox MB;

	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void Release ()
	{
		rb.useGravity = true;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag != "Player" && !MB.dashing) {
			rb.constraints = RigidbodyConstraints.FreezeAll;

		} else if (MB.dashing) {

			Destroy (this.gameObject);
		}
	}
}
