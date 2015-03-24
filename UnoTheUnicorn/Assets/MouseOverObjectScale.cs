using UnityEngine;
using System.Collections;

public class MouseOverObjectScale : MonoBehaviour {
	public Renderer scaleBridgePart;
	public Vector3 scaleVector;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseEnter(){
		Scale(true);
	}
	void OnMouseExit(){
		Scale(false);
	}
	void Scale(bool on)
	{
		float direction;
		
		if(on)
		{
			direction = 1.0f;
			Debug.Log("Enter");
		}
		else
		{
			direction = -1.0f;
			Debug.Log("Exit");
		}
		
		const float amount = 0.5f; 
		ScalingObject(amount * direction);
	}
	
	void ScalingObject(float size)
	{
		transform.localScale += CreateVector(size);
	}
	
	Vector3 CreateVector(float size)
	{
		return new Vector3(size,size,size);
	}
}