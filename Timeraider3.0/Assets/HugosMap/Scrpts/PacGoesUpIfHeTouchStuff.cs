using UnityEngine;
using System.Collections;

public class PacGoesUpIfHeTouchStuff : MonoBehaviour {

	public float moveSpeed = 0.1f;
	public float x;
	bool PacGoesUpIfHeTouchWallElseDown = false;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Wall"){
			PacGoesUpIfHeTouchWallElseDown = true;

		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Wall"){
			PacGoesUpIfHeTouchWallElseDown = false;
			
		}
	}
	public void PacHeadOnRoof(){
		PacGoesUpIfHeTouchWallElseDown = false;

	}
	public void PacNotHeadOnRoof(){
		PacGoesUpIfHeTouchWallElseDown = false;
	}

	public void PacDash(){
		moveSpeed = moveSpeed * 2;
	}
	public void PacStopedDash(){
		moveSpeed = moveSpeed / 2;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (PacGoesUpIfHeTouchWallElseDown){
			transform.parent.position += Vector3.up * Time.deltaTime * moveSpeed;
		}
//		if ( GetComponentInParent<MoveBox>().direction == 4){
//			PacGoesUpIfHeTouchWallElseDown = false;
//		}
	
	}
}
