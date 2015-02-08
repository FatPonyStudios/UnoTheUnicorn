using UnityEngine;
using System.Collections;

public delegate void ClickDelegate(Vector2 ClickCoordinates);

public class ClickCatcher : MonoBehaviour {

    public event ClickDelegate MouseClickEvent; 

    // Use this for initialization
	void Start () {

	}
	void OnUnoMoved (Vector3 position)//Exempel AK
	{
		Debug.Log("HejHopp");
	}

	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 mouseClickCoordinates = Input.mousePosition;

			var worldPosition = Camera.main.ScreenToWorldPoint(mouseClickCoordinates);
			Debug.Log(worldPosition);
            if (MouseClickEvent != null)
            {
                MouseClickEvent(worldPosition);
            }
        }
	}

    /*
    void SetTarget()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            screenVector = Input.mousePosition;
            targetVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetVector.z = transform.position.z;

            /*
            if (ClickEvent != null)
            {
                ClickEvent("Mouse coordinate: " + Input.mousePosition.ToString());
                ClickEvent("World coordinate: " + targetVector.ToString());
            }
            
        }
    }
    
    /*
    void MoveToTarget()
    {
        Vector3 newPosition = transform.position;
        bool TargetReaced = false;

        if (newPosition == targetVector)
        {
            TargetReaced = true;
            if (ClickEvent != null)
                ClickEvent("Target reached");
        }

        
        if (!TargetReaced)
        {
            if (targetVector.x < transform.position.x)
            {
                newPosition.x -= 0.1f;
            }

            if (targetVector.x > transform.position.x)
            {
                newPosition.x += 0.1f;
            }

            if (targetVector.y < transform.position.y)
            {
                newPosition.y -= 0.1f;
            }

            if (targetVector.y > transform.position.y)
            {
                newPosition.y += 0.1f;
            }

            transform.position = newPosition;
        }
        
    }
    */
}
