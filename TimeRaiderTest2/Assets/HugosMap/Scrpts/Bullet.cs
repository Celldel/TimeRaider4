using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int bulletSpeed;
	public float travelTime;
	Vector3 spawnPoint;
	bool shooting;
	float timer;
	public float startDelay;



	// Use this for initialization
	void Start () {

		spawnPoint = gameObject.transform.position;

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		timer += Time.deltaTime;
		if (shooting) {
			transform.Translate (Vector3.right * Time.deltaTime * bulletSpeed);
		}

		if (timer > startDelay && !shooting) {
			shooting = true;
			timer = 0;
		}
		else if (timer > travelTime && shooting) {
			transform.position = spawnPoint;
			timer = 0;
		}

	}


}
