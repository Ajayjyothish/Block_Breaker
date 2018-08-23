using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {

    [SerializeField] float screen_width_limit ;

    GameStatus status;
    Ball ball;
    float mouse_x;


    // Use this for initialization
    void Start () {
        status = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        mouse_x = Input.mousePosition.x / Screen.width * screen_width_limit;
        Vector2 paddlePos = new Vector2(paddle_x(), transform.position.y);

        transform.position = paddlePos;
    }

    private float paddle_x()
    {
        if (status.IsAutoPlayOn())
        {
            return ball.transform.position.x;
        }
        else

        return Mathf.Clamp(mouse_x, 0.5f, 7.5f);
    }
}
