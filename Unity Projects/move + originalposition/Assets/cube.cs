using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class cube : MonoBehaviour
{
    private Vector3 dislodge;
    private Vector3 screenPoint;
    private Vector3 originalposition; 
    private bool areaReached;
    private bool drag;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
            originalposition = gameObject.transform.position;
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            dislodge = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + dislodge;
        transform.position = curPosition;

    }
    void OnMouseUp()
    {
            
                gameObject.transform.position = originalposition;       
    }
    void OnTriggerEnter(Collider collider)
    {
        // detect if the object enters the area
        if (collider.gameObject.name == "cube")
        {
            // get object's script and modify its variable
            cube obj = collider.gameObject.GetComponent<cube>();
            obj.areaReached = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        // set it back to false if the object leaves the area before OnMouseUp
        if (collider.gameObject.name == "cube")
        {
            cube obj = collider.gameObject.GetComponent<cube>();
            obj.areaReached = false;
        }
    }
}
   
