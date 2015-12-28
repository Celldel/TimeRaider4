using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int bulletSpeed;
	public float travelTime;
	Vector3 spawnPoint;
	bool shooting;
	float time;
	public float startDelay;



	// Use this for initialization
	void Start () {

		spawnPoint = gameObject.transform.position;

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		time += Time.deltaTime;
		transform.Translate (Vector3.right * Time.deltaTime * bulletSpeed);



		if (time > travelTime && shooting) {
			transform.position = spawnPoint;
			time = 0;
		}

	}


}
