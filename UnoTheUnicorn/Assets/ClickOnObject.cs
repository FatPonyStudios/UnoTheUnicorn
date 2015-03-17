using UnityEngine;
using System.Collections;

public class ClickOnObject : MonoBehaviour {
	public GameObject ThoughtBubble;
	// Use this for initialization
	void Start () {
		ThoughtBubble.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		Debug.Log("Hello");
		ThoughtBubble.GetComponent<Renderer>().enabled = true;

		StartCoroutine("WaitThreeSeconds");
	}

	IEnumerator WaitThreeSeconds()
	{
		yield return new WaitForSeconds(3);
		Debug.Log("Waiting");
		ThoughtBubble.GetComponent<Renderer>().enabled = false;
	}
}