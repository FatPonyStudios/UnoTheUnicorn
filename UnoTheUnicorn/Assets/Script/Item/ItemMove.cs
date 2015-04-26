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
    private GameObject player = GameObject.FindWithTag("Uno");
    
    

	// Use this for initialization
	void Start () 
    {
       // player.GetComponent<MoveToClick>().movingAllowed = false;  
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnMouseDown()
    {
       
        originalposition = gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = originalposition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 screenPointForMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(screenPointForMouse) + offset;
        transform.position = mousePosition;

    }
    void OnMouseUp()
    {
        
		if (!PutItemInRightPosition ()) 
		{
			gameObject.transform.position = originalposition;
		}
    


    //GameObject SetItem()
    //{
    //    testOfItem = GameObject.Find("TestItem2");
    //    testOfItem.transform.parent = null;
    //    return testOfItem;
	}
	
    //void OnColliderEnter(Collider c)
    //{
    //    if (c.gameObject.name == "TestItem2")
			
    //    { SetItem().transform.parent = gameObject.transform; }
//}
	
	bool PutItemInRightPosition()
	{
		
		var findEmptyObject = FindObjectsOfType<BridgePartEmpty>();
		foreach (var emptyObjectPosition in findEmptyObject)
		{
			if (emptyObjectPosition.bridgePartName == gameObject.name)
			{
				if(CheckIsItemNearToRightPosition(emptyObjectPosition.transform.position)) //här används samma två gg, ska den göras till en variabel?
				{
					transform.position = emptyObjectPosition.transform.position;
					return true;
				}
			}
		}
	
		return false;
	}
	bool CheckIsItemNearToRightPosition(Vector3 targetCoordinate)
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