using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{

    public float speed;
    private float direction;
    public float rightBoundary;
    public float leftBoundary;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(speed * direction, 0);
        transform.Translate(movement * Time.deltaTime);
        if (facingRight && transform.position.x >= rightBoundary)
        {
            direction = -1;
            facingRight = false;

        }
        if (!facingRight && transform.position.x <= leftBoundary)
        {
            direction = 1;
            facingRight = true;
        }
    }
}
