using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetBehavior : MonoBehaviour
{
    //set left position value for x
    public float left;

    //set right position value for x
    public float right;

    bool movingRight, movingLeft;

    void Start()
    {
        movingRight = true;
    }

    void FixedUpdate()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * 0.2f;
            
            //when it reaches the right corner, start moving left
            if (transform.position.x > right)
            {
                movingRight = false;
                movingLeft = true;
            }
        }

        if (movingLeft)
        {
            transform.position += Vector3.left * 0.2f;

            //when it reaches the right corner, start moving left
            if (transform.position.x < left)
            {
                movingLeft = false;
                movingRight = true;
            }
        }
    }
}
