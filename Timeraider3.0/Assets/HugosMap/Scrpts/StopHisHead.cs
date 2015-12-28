using UnityEngine;
using System.Collections;

public class StopHisHead : MonoBehaviour {

	PacGoesUpIfHeTouchStuff pacGoesUpIfHeTouchStuff;
	public GameObject headCollider;

	DownWithPack downWithPack;
	public GameObject pacDontMoveUpAnymore;
	// Use this for initialization
	void Start () {
		pacGoesUpIfHeTouchStuff = headCollider.gameObject.GetComponent<PacGoesUpIfHeTouchStuff>();
		downWithPack = pacDontMoveUpAnymore.gameObject.GetComponent<DownWithPack>();
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Wall"){
			pacGoesUpIfHeTouchStuff.PacHeadOnRoof();
			downWithPack.StopTheMovement();
	
		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Wall"){
			pacGoesUpIfHeTouchStuff.PacNotHeadOnRoof();
			downWithPack.StopTheMovement();
			
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
