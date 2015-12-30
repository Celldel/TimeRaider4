using UnityEngine;
using System.Collections;


public class EnemyMovement : MonoBehaviour {

	public GameObject pacman;
	public GameObject[] patrolPoints;
	int index = 0;
	public float[] huntingEnemySpeedAndAcc = new float[2];
	public float[] patrollingEnemySpeedAndAcc = new float[2];

	//public bool patroller;



	void Start () {
		
			Invoke ("Patrol", 0);

	
	}


	void HuntPacman ()
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();

		agent.speed = huntingEnemySpeedAndAcc[0];
		agent.acceleration = huntingEnemySpeedAndAcc[1];
		agent.autoBraking = false;
		agent.destination = pacman.transform.position;
	}

	void Patrol ()
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();

		agent.speed = patrollingEnemySpeedAndAcc[0];
		agent.acceleration = patrollingEnemySpeedAndAcc[1];
		agent.autoBraking = true;
		agent.destination = patrolPoints [index].transform.position;
			
	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject == patrolPoints [index]) {
			index = (index + 1) % patrolPoints.Length;

			Invoke ("Patrol", 0);
		}
	}

}
