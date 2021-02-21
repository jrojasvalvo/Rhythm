using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject arrow;
    public GameObject ball;
    public Vector3 highBallInitPos = new Vector3(11f, 2f, 0f);
    public Vector3 lowBallInitPos = new Vector3(11f, -2f, 0f);
    public Vector3 highArrowInitPos = new Vector3(-4f, 2f, 0f);
    public Vector3 lowArrowInitPos = new Vector3(-4f, -2f, 0f);
    public bool high = true;

    // Start is called before the first frame update
    void Start()
    {   
        if (high) {
            arrow.transform.position = highArrowInitPos;
            ball.transform.position = highBallInitPos;
        } else {
            arrow.transform.position = lowArrowInitPos;
            ball.transform.position = lowBallInitPos;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ball.transform.position = new Vector3(ball.transform.position.x - speed, 
                                                ball.transform.position.y, 
                                                ball.transform.position.z);

        arrow.transform.position = new Vector3(arrow.transform.position.x - speed, 
                                                arrow.transform.position.y, 
                                                arrow.transform.position.z);
    }

}
