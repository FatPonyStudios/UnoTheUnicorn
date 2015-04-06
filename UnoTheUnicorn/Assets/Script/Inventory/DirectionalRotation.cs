using UnityEngine;
using System.Collections;

public class DirectionalRotation : MonoBehaviour 
{
	Vector3 previousPosition;


	// Use this for initialization
	void Start () 
	{
		previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckandChangeDirection();
	}


	void CheckandChangeDirection()
	{
		Vector3 newPosition = transform.position-previousPosition;
		previousPosition = transform.position;
		float X;
		
		if (newPosition.x < 0) {
			X = 0;
		} else if (newPosition.x > 0) {
			X = 180;
		} else 
		{
			return;
		}
		transform.localEulerAngles = new Vector3 (0, X, 0);


	}




}
