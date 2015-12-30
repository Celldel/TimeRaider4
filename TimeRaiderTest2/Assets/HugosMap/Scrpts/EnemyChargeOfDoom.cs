using UnityEngine;
using System.Collections;

public class EnemyChargeOfDoom : MonoBehaviour {
//	public GameObject ghost;
	public GameObject pacMan;
	public Transform enter;
	public Transform exit;
	public float moveSpeed = 2;
	public float ghostMaxSpeed;
	public float startMoveSpeed;
	public bool pacIsIn;
	public bool activateGhostSearch;
	public bool ghostSearchForPac = true;
	int pacManLayer = 1<<9;
	public float ghostFlyTime;

	public float turnSpeed;
	Vector3 wherePacIsPos;
	RaycastHit ghostHit;


	//_____________Ghost Go Back__________

	public Transform enemyDirection;
	RaycastHit hit;
	int enemyLayerMask = 1<<10;
	public bool goBackAndLookAtPac;







	//____________________________________________-
	void Start () {
		startMoveSpeed = moveSpeed;

	}

	IEnumerator StartRaycast(){
		ghostSearchForPac = false;
		pacIsIn = true;
		yield return new WaitForSeconds(ghostFlyTime);

		if(pacIsIn || !ghostSearchForPac){
			pacIsIn = false;
			ghostSearchForPac = true;
			moveSpeed = startMoveSpeed;
		}



	}
	public void StartGhost(){
		activateGhostSearch = true;
		goBackAndLookAtPac = false;
	}
	public void StopGhost(){
		activateGhostSearch = false;
		goBackAndLookAtPac = true;

	}
	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "SuperWall"){
			pacIsIn = false;
			ghostSearchForPac = true;
			moveSpeed = startMoveSpeed;
		}
			
	}
	
	// Update is called once per framed
	void FixedUpdate () {


	
		if(activateGhostSearch)	{
			if (ghostSearchForPac){

				if (Physics.Raycast(transform.position,this.transform.forward,out ghostHit, 50f, pacManLayer)){
					if (ghostHit.collider.tag == "Player"){
						StartCoroutine(StartRaycast());
					}else{
						transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(pacMan.transform.position - transform.position), turnSpeed * Time.deltaTime) ;   
						}
				}else{
						transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(pacMan.transform.position - transform.position), turnSpeed * Time.deltaTime) ;  
					}
			}


			if (pacIsIn){

				transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

				if (moveSpeed <= ghostMaxSpeed){
					moveSpeed  += 2*moveSpeed * Time.deltaTime;
				} 
			}
		}else{

			if(goBackAndLookAtPac){
				if(Physics.Raycast(transform.position,this.transform.forward,out hit,50F,enemyLayerMask)){
								Debug.Log(hit.collider.gameObject);
					if(hit.collider.gameObject == enemyDirection.gameObject){
						transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
					}
					else{
						transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(enemyDirection.position - transform.position), turnSpeed * Time.deltaTime) ;   
					}
				}
				else{
					transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(enemyDirection.position - transform.position), turnSpeed * Time.deltaTime) ;  
					//			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(enemyDirection[index].transform.position), turnSpeed * Time.deltaTime);
				}
				if(Physics.Raycast(transform.position,this.transform.forward,out hit,0.5f,enemyLayerMask)){
					if(hit.collider.gameObject == enemyDirection.gameObject){
						goBackAndLookAtPac = false;
					}
				}
			}
			else{
				transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(pacMan.transform.position - transform.position), turnSpeed * Time.deltaTime) ; 
			}
		}
	}



	}

