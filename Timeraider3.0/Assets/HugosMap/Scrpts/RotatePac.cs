using UnityEngine;
using System.Collections;

public class RotatePac : MonoBehaviour {

	// Use this for initialization

		public int rotateDirection;
		Vector3[] lookAtDir;

		void Start ()
		{
			lookAtDir = new Vector3[] {Vector3.forward,-Vector3.forward,Vector3.right,-Vector3.right};
		}

		// Update is called once per frame
		
			public void EyPacMovedFromLocation() 
			{
				rotateDirection = GetComponentInParent<MoveBox>().direction;
				transform.LookAt(lookAtDir[rotateDirection]);

			}
}