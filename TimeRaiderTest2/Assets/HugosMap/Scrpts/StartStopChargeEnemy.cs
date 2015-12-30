using UnityEngine;
using System.Collections;

public class StartStopChargeEnemy : MonoBehaviour {

	public GameObject chargingEnemy;
	RaycastHit enterHit;
	RaycastHit exitHit;
	int pacManLayer = 1<<9;


	EnemyChargeOfDoom enemyChargeOfDoom;

	// Use this for initialization
	void Start () {
		enemyChargeOfDoom = chargingEnemy.gameObject.GetComponent<EnemyChargeOfDoom>();
 
	}
	
	// Update is called once per frame
	void Update () {
	

		if(Physics.Raycast(transform.position,-Vector3.right, out enterHit, 50f,pacManLayer)){

			if(enterHit.collider.tag == "Player"){
				enemyChargeOfDoom.StartGhost();
			}
		}
		if (Physics.Raycast(transform.position + new Vector3(0,-0.5f,0),-Vector3.right, out exitHit, 50f,pacManLayer)){
			if(exitHit.collider.tag == "Player"){
				enemyChargeOfDoom.StopGhost();
			}

		}
	}
}
