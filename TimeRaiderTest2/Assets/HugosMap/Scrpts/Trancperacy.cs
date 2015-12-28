using UnityEngine;
using System.Collections;

public class Trancperacy : MonoBehaviour {

	public GameObject HeadSphere;
	public GameObject[] teleportLocationObjects;
	Color color;
	float chargeValue = 0;
	bool holdButtonToCharge;
	// Use this for initialization
	void Start () {
		color = HeadSphere.gameObject.GetComponent<MeshRenderer>().material.color;
		color.a = chargeValue;
		HeadSphere.gameObject.GetComponent<MeshRenderer>().material.color = color;

	}





	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space)){
			HeadSphere.gameObject.SetActive(true);
			holdButtonToCharge = true;
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			chargeValue = 0;
			holdButtonToCharge = false;
			color.a = chargeValue;
			HeadSphere.gameObject.GetComponent<MeshRenderer>().material.color = color;
			HeadSphere.gameObject.SetActive(false);

		}

	}
	void FixedUpdate(){

		if (holdButtonToCharge){
			chargeValue += Time.deltaTime;
			color.a = chargeValue;
			HeadSphere.gameObject.GetComponent<MeshRenderer>().material.color = color;
		}


	}
}
