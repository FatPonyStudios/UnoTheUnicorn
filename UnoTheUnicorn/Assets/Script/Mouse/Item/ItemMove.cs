using UnityEngine;
using System.Collections;


public class ItemMove : MonoBehaviour {

    private Vector3 offset;
    private Vector3 screenPoint;
    private Vector3 originalposition;
    private bool areaReached;
    private bool drag;
    public GameObject testOfItem;
    private Collider collie;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        originalposition = gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }
    void OnMouseUp()
    {
		if (!PutItemInRightPosition ()) 
		{
			gameObject.transform.position = originalposition;
		}
    }


	GameObject SetItem()
	{
		testOfItem = GameObject.Find("TestItem2");
		testOfItem.transform.parent = null;
		return testOfItem;
	}
	//    void OnTriggerEnter(Collider mytrigger)
	//    {
	//        if (mytrigger.gameObject.name == "TestItem2")
	//        {
	//            SetItem().transform.parent = gameObject.transform;
	//}
	void OnColliderEnter(Collider c)
	{
		if (c.gameObject.name == "TestItem2")
			
		{ SetItem().transform.parent = gameObject.transform; }
	}
	
	bool PutItemInRightPosition()
	{
		
		var posTest1 = FindObjectsOfType<BridgePartEmpty>();
		foreach (var emptyPos in posTest1)
		{
			if (emptyPos.bridgePartName == gameObject.name)
			{
				if(ItemNearToRightPositionCheck(emptyPos.transform.position))
				{
					transform.position = emptyPos.transform.position;
					return true;
				}
			}
		}
	
		return false;
	}
	bool ItemNearToRightPositionCheck(Vector3 targetCoordinate)
	{
		const float minimalPositionDiff = 1.0f; 
		var distanceLeft = targetCoordinate - transform.position;

		if(distanceLeft.magnitude < minimalPositionDiff)
		{
			return true;
		}
		return false;
	}


}