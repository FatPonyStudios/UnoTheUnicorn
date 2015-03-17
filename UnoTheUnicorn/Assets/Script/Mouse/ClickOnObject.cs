using UnityEngine;
using System.Collections;

public class ClickOnObject : MonoBehaviour {
	public Renderer ThoughtBubble;
	float bubbleShownAtTime;
	// Use this for initialization
	
	void Start () {
		ShowBubble(false);

	}
	
	// Update is called once per frame
	void Update () {
		CheckIfWeShouldCloseBubble();
	}
	
	void CheckIfWeShouldCloseBubble()
	{
		if (IsBubbleDisplayed() && TimeToHideBubble())
		{
			ShowBubble(false);
		}
	}
	
	void OnMouseDown()
	{
		Debug.Log("Hello");
		ShowBubble(true);
		
	}
	
	bool IsBubbleDisplayed()
	{
		return ThoughtBubble.enabled;
	}
	
	bool TimeToHideBubble()
	{
		const float secondsBubbleIsShown = 3.0f;
		return Time.time >= bubbleShownAtTime + secondsBubbleIsShown;
	}
	
	void ShowBubble(bool on)
	{
		if (on) {
			bubbleShownAtTime = Time.time;
		}
		ThoughtBubble.enabled = on;
	}
	
	
	
	
	
	
}