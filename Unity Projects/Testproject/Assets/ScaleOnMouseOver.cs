using UnityEngine;
using System.Collections;

public class ScaleOnMouseOver : MonoBehaviour {
	public Renderer BridgePart;
	public float scale = 1.0f;
	public Vector3 theScale;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void CheckResizeObject()
	{
if (ScaleObject ()) {
		
		}
	}

	void OnMouseOver()
	{
		ScaleObject (true);
		Debug.Log ("Hooover");
	}

	void ScaleObject(bool on)
	{
		if (on) {

			transform.localScale += new Vector3 (0.2f, 0.2f, 0.2f);
		}
	}
	}
