using UnityEngine;
using System.Collections;

public enum SpriteState
{
    Moving,
    Idle
}


public class MoveToClick : MonoBehaviour 
{
	public delegate void ClickDelegate (Vector3 position);
    public ClickDelegate UnicornPosition;
	public ClickCatcher clickCatcher;  //*Ej static. Kan stoppa in olika versioner av ClickCatcher och det ändras automatiskt. Exempel fiender.
    
	float[] spriteOffset;
    int currentSpriteFrame = 0;

    Vector2 targetCoordinate;
    public SpriteState state;
    
    void Start () 
    {
        clickCatcher.MouseClickEvent += SetTarget;//*
        targetCoordinate = transform.position;
        spriteOffset = new float[6]{0.0f, 0.166666667f, 0.333333333f, 0.5f, 0.666666667f, 0.833333333f};
        state = SpriteState.Idle;
	}
	
	void Update () 
    {
        MoveUnicorn();
        AnimateUnicorn();

        if (UnicornPosition != null)
            UnicornPosition(transform.position);

	}

    void SetTarget(Vector2 target)
    {
		SendMessage ("OnUnoMoved", transform.position, SendMessageOptions.RequireReceiver); //Exempel AK
		targetCoordinate = target;
        //Debug.Log("=====================================================" + targetCoordinate);
        //Debug.Log(transform.position);
    }

    void MoveUnicorn()
    {
        
        bool TargetReached = false;

        Vector2 newPosition = transform.position;
		const float minimalPositionDiff = 0.1f; //Ej siffror i koden, samla under ett namn. Lättare att bara ändra på ett ställe. Mindre diff.
        if (newPosition.x - minimalPositionDiff < targetCoordinate.x && newPosition.x + minimalPositionDiff > targetCoordinate.x && newPosition.y - minimalPositionDiff < targetCoordinate.y && newPosition.y + minimalPositionDiff > targetCoordinate.y)
        {
          	TargetReached = true;
            state = SpriteState.Idle;
        }

        if (!TargetReached)
        {
            state = SpriteState.Moving;
            if (targetCoordinate.x < transform.position.x)
            {
                newPosition.x -= 0.1f;
            }

            if (targetCoordinate.x > transform.position.x)
            {
                newPosition.x += 0.1f;
            }

            if (targetCoordinate.y < transform.position.y)
            {
                newPosition.y -= 0.1f;
            }

            if (targetCoordinate.y > transform.position.y)
            {
                newPosition.y += 0.1f;
            }

            transform.position = newPosition;
        }   
    }

    void AnimateUnicorn()
    {
        if (state != SpriteState.Idle)
        {
            currentSpriteFrame++;
            if (currentSpriteFrame > spriteOffset.Length-1)
                currentSpriteFrame = 0;
        }

        if (state == SpriteState.Idle)
        {
            currentSpriteFrame = 0;
        }

        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(spriteOffset[currentSpriteFrame], 0));
    }
}
