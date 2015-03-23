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
		if(on)
		{
			Debug.Log("Enter");
			transform.localScale += new Vector3(0.5f,0.5f,0.5f);

		}
		else
		{
			Debug.Log("Exit");
			transform.localScale -= new Vector3(0.5f,0.5f,0.5f);
			
		}
}
}