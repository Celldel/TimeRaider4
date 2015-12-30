using UnityEngine;
using System.Collections;

public class EnemyMoveMario : MonoBehaviour {

	public Transform[] enemyDirection;
	public float turnSpeed;
	public float moveSpeed;
	public int index;
	RaycastHit hit;
	int enemyLayerMask = 1<<10;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void FixedUpdate () {  

		Debug.DrawRay(transform.position,this.transform.forward * 50F, Color.red);
		Debug.DrawRay(transform.position,Vector3.forward * 0.5f, Color.red);



		if(Physics.Raycast(transform.position,this.transform.forward,out hit,50F,enemyLayerMask)){
//			Debug.Log(hit.collider.gameObject);
			if(hit.collider.gameObject == enemyDirection[index].gameObject){

				transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
			}
			else{
				transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(enemyDirection[index].transform.position - transform.position), turnSpeed * Time.deltaTime) ;   
			}
		}
		else{
			transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(enemyDirection[index].position - transform.position), turnSpeed * Time.deltaTime) ;  
//			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(enemyDirection[index].transform.position), turnSpeed * Time.deltaTime);
		}


		if(Physics.Raycast(transform.position,this.transform.forward,out hit,0.5f,enemyLayerMask)){
			if(hit.collider.gameObject == enemyDirection[index].gameObject){
				index = (index + 1) % enemyDirection.Length;
			}
		}





	 
	}
}
