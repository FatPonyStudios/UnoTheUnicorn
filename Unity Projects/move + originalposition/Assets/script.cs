using UnityEngine;
using System.Collections;


public class script : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        MoveUpDownLeftRight();
        JumpWithKeywordJ();
    }
    void MoveUpDownLeftRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y--;
            this.transform.position = position;
        }
    }
    void JumpWithKeywordJ()
    {
        var rotationSpeed = 100;
        var jumpHeight = 20;
        var isFalling = false;
      
        var rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        rigidbody.AddRelativeTorque(Vector3.back * rotation);

        if (Input.GetKeyDown(KeyCode.J) && isFalling == false)
        {
            Vector3 v = rigidbody.velocity;
            v.y = jumpHeight;
            rigidbody.velocity = v;
            isFalling = true;
        }

    }
}

