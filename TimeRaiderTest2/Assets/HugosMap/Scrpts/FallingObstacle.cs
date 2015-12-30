using UnityEngine;
using System.Collections;

public class FallingObstacle : MonoBehaviour {

	public MoveBox MB;
	public float speed;
	public GameObject[] meteors;

	void Start ()
	{
		MB = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveBox> ();
	}

	void FixedUpdate ()
	{
		meteors[0].transform.Translate (Vector3.right * Time.deltaTime * speed);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag != "Player" && !MB.dashing) {
			
			meteors [0].SetActive (false);
			meteors [1].SetActive (true);

		} else if (MB.dashing) {

			Destroy (this.gameObject);

		}
	}
}
