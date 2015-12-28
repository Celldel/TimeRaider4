using UnityEngine;
using System.Collections;

public class DownWithPack : MonoBehaviour {

	//______________Gravity_____________
	public bool pacDontTouchTheFloor = true;
	public float moveSpeed;
	public int enterExit;

	//______________Jump_________________

	public KeyCode jumpUp;
	public bool jumpOkOrNot = false;
	public bool jumpKeyPressed = true;

	public float timer4HowLongJump;

	public float x;
	public float y = 0;

	public float rayLeangth;

	RaycastHit hit;

	public bool pacCanNowJump = true;

	bool pacDash = false;

//	//______PacWalkUp_______
//	Vector3[] raycastDir;
//	Vector3[] offset;
//
//	raycastDir = new Vector3[] {Vector3.forward, -Vector3.forward, Vector3.right,-Vector3.right};

	// Use this for initialization
	void Start () {
		
	}

	public void PacIsDashing(){
		pacDash = true;
	}
	public void PacStopedDashing(){
		pacDash = false;
	}

	public void PacHasEatenTheJumpPillAndCanNowJumpLol(){
		pacCanNowJump = true;
	}
	public void StopTheMovement(){

		if (x > 0){
			x = 0.2f;
		}
		jumpOkOrNot = false;
	}
	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Wall"){
			enterExit++;
			pacDontTouchTheFloor = false;
			jumpKeyPressed = true;
			x = 0;
		}
	}
	void OnTriggerExit(Collider col){

		if (col.gameObject.tag == "Wall"){
			enterExit--;
			if(enterExit == 0){
				pacDontTouchTheFloor = true;
				enterExit = 0;
			}

		}
	}

	void Update(){


		if (jumpKeyPressed && !pacDontTouchTheFloor && pacCanNowJump){
			if (Input.GetKeyDown(jumpUp)){
					x = 7;	
			}
		}

		else if (Input.GetKeyUp(jumpUp) && jumpKeyPressed ){
			jumpKeyPressed = false;
			StartCoroutine(EyTappaHoppBre());
		}
	}
	//____Delay på när man släpper knappen och när PacFaller
	IEnumerator EyTappaHoppBre() {
		yield return new WaitForSeconds(0.1f);
		if (x > 0){
			x = 0.2f;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {






	
		y += Time.deltaTime;


		if (x > 0){
		transform.parent.position += transform.up * Time.deltaTime * x;
		}
		//____________For Jump_____________
		if (!pacDash){


			if (pacDontTouchTheFloor && x < 0.5f ){
				
				transform.parent.position += -transform.up * Time.deltaTime * -x;
				
				if (x > -7){
					x -= 7*Time.deltaTime;
				}
				
			}
			
			if (x > 0){
					x -= 7*Time.deltaTime;
				if( x < 0){
					x = 0;
				}
			}
		}
	}
}
