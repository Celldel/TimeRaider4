using UnityEngine;
using System.Collections;

public class TeleportPac : MonoBehaviour {
	public Transform[] teleportLocation;
	public KeyCode upMovement;
	public KeyCode downMovement;
	public KeyCode rightMovement;
	public KeyCode leftMovement;
	public KeyCode teleportButton;
	int nextDirection;
	public bool herculesMode;

	//____Pac Get Teleport PowerUp________
	public bool pacActivateTeleport;

	public bool rightIsColliding;
	public bool leftIsColliding;


	//____Raycast_______
	Vector3[] raycastStartpoint1;
	Vector3[] raycastStartpoint2;
	Vector3[] raycastDirection;
	public float distanceFromTransform = 0.5f;

	RaycastHit[] hitsFromPac;
	RaycastHit[] hits2Pac;
	RaycastHit[] hits3Pac;
	RaycastHit[] hits4Pac;

	int pacLayerMask = 1 << 8 | 1 << 9;
	int wallLayermask = 1 << 9;

	//______TeleportCharging_____________
	public float chargeValue;
	public float chargeIsDoneAndGood2Go = 1;
	public bool holdingTheChargeButton;

	//________Show when charge is rdy_______
	public GameObject[] teleportLocationObjects;
	public bool showTheGameObject;
	public bool ThinkINeedThis;

	Color color;
	Color colorPac;
	//_____________Particle______________
	public GameObject[] particle;

	// Use this for initialization
	void Start () {
		raycastDirection = new Vector3[] {Vector3.forward,-Vector3.forward,Vector3.right,-Vector3.right};
		colorPac = GetComponent<MeshRenderer>().material.color;
		//____Make all teleportationpoints Transparent______
		MakeAllTeleportationpointsTransparent();
		SetAllBoxesNotActiveMabye();

	}

	public void PacActivadetTheTeleport()
	{
		pacActivateTeleport = true;
	}

	public void PacTeleport()
	{ 
		StartCoroutine(TeleportAfterEffect());
		transform.position = teleportLocation[nextDirection].position;
	}
	IEnumerator TeleportAfterEffect(){
		particle[0].gameObject.transform.position = transform.position;
		particle[1].gameObject.transform.position = teleportLocation[nextDirection].position;
		particle[0].gameObject.SetActive(true);
		particle[1].gameObject.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		particle[0].gameObject.SetActive(false);
		particle[1].gameObject.SetActive(false);

	}
	public void SetAllBoxesNotActiveMabye(){

		for (int i = 0; i < teleportLocationObjects.Length; i++){
			teleportLocationObjects[i].gameObject.SetActive(false);
		}
		if (holdingTheChargeButton){
			teleportLocationObjects[nextDirection].gameObject.SetActive(true);
		}

	}
		
	public void MakeAllTeleportationpointsTransparent(){
		for (int i = 0; i < teleportLocationObjects.Length; i++){
			color = teleportLocationObjects[i].gameObject.GetComponent<MeshRenderer>().material.color;
			color.a = 0f;
			teleportLocationObjects[i].gameObject.GetComponent<MeshRenderer>().material.color = color;
		}
	}
	public void MakeOneTeleportationpointsTransparent(){

		color = teleportLocationObjects[nextDirection].gameObject.GetComponent<MeshRenderer>().material.color;

		color.a = chargeValue* 0.8f -0.3f;
		teleportLocationObjects[nextDirection].gameObject.GetComponent<MeshRenderer>().material.color = color;
	}
	public void MakePacTransparent(){

		colorPac = GetComponent<MeshRenderer>().material.color; 
		if(colorPac.a > 0.7f)
			colorPac.a = -chargeValue+1F;
		GetComponent<MeshRenderer>().material.color = colorPac;
	}
	void Fade() {
		//		for (float f = 1f; f >= 0; f -= 0.1f) {
		//			Color c = GetComponent<Renderer>().material.color;
		//			c.a = f;
		//			GetComponent<Renderer>().material.color = c;
		//		}
			}


	// Gör en Metod i Colliders så de Resetar sig!! GLÖM INTE MARIO!!!! FITTUNGE '

	// Update is called once per frame
	void Update () {

		if(Input.GetKey(upMovement) && !herculesMode){
			nextDirection = 0;
			MakeOneTeleportationpointsTransparent();
		}else if(Input.GetKey(downMovement) && !herculesMode){ 
			nextDirection = 1;
			MakeOneTeleportationpointsTransparent();
		}else if(Input.GetKey(rightMovement)){
			nextDirection = 2;
			MakeOneTeleportationpointsTransparent();
		}else if(Input.GetKey(leftMovement)){
			nextDirection = 3;
			MakeOneTeleportationpointsTransparent();
		}


		if(pacActivateTeleport && Input.GetKeyDown(teleportButton)){
			holdingTheChargeButton = true;

		}

		if(Input.GetKeyUp(teleportButton)){

			//_____Raycast______________________________________________________________________________________________________
			if (chargeValue >= chargeIsDoneAndGood2Go) {

				raycastStartpoint1 = new Vector3[] {
					teleportLocation[nextDirection].position + new Vector3(0,0,distanceFromTransform),
					teleportLocation[nextDirection].position + new Vector3(0,0,-distanceFromTransform), 
					teleportLocation[nextDirection].position + new Vector3(distanceFromTransform,0,0),
					teleportLocation[nextDirection].position + new Vector3(-distanceFromTransform,0,0)};

				raycastStartpoint2 = new Vector3[] {
					teleportLocation[nextDirection].position + new Vector3(0,0,-distanceFromTransform),
					teleportLocation[nextDirection].position + new Vector3(0,0,distanceFromTransform), 
					teleportLocation[nextDirection].position + new Vector3(-distanceFromTransform,0,0),
					teleportLocation[nextDirection].position + new Vector3(distanceFromTransform,0,0)};

				hitsFromPac = Physics.RaycastAll(transform.position,raycastDirection[nextDirection], 3F,  pacLayerMask | wallLayermask);
				hits2Pac = Physics.RaycastAll(raycastStartpoint1[nextDirection],-raycastDirection[nextDirection], 3F,  pacLayerMask | wallLayermask);
				hits3Pac = Physics.RaycastAll(teleportLocation[nextDirection].position,-raycastDirection[nextDirection], 3F,  pacLayerMask | wallLayermask);
				hits4Pac = Physics.RaycastAll(raycastStartpoint2[nextDirection],-raycastDirection[nextDirection], 3F,  pacLayerMask | wallLayermask);

				if (hitsFromPac.Length != hits2Pac.Length && hitsFromPac.Length != hits3Pac.Length && hitsFromPac.Length != hits4Pac.Length)
				{
					PacTeleport();			
				}
				//________________________________________________________________________________________________________________________________________________

			}
			//____Charge____
			holdingTheChargeButton = false;
			chargeValue = 0;

			MakeAllTeleportationpointsTransparent();
			SetAllBoxesNotActiveMabye();





			//_________________

		}
		}
	void FixedUpdate () {
		//_______Charge_______________
		if(holdingTheChargeButton){
			if(chargeValue < 1){
				chargeValue += Time.deltaTime;

			}
			SetAllBoxesNotActiveMabye();


		}

		//________Show GameObject when charge is rdy____
		//			if (chargeValue >= chargeIsDoneAndGood2Go){
		//				SetAllBoxesNotActiveMabye();
		//		//		holdingTheChargeButton = false;

		//			}
		if(teleportLocationObjects[nextDirection].gameObject.activeSelf){
			MakeOneTeleportationpointsTransparent();
			MakePacTransparent();
		}
		else if (colorPac.a < 1){
			Debug.Log("Ey");
			colorPac.a += Time.deltaTime;
			GetComponent<MeshRenderer>().material.color = colorPac;
		}
	}
}
	
	 //

	//	if(Physics.Raycast(raycastStartpoint[direction],raycastDirection,   ))
	

























