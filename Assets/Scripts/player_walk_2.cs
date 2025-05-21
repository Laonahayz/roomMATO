using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_walk_2 : MonoBehaviour
{
    public GameObject player;
    float speedUD = 0.0020f;
    float speedLR = 0.0015f;
    float x = 0.05f;
    float y = -5.39f;
    float Walk_Down_x, Walk_Down_y;
    float Walk_Up_x, Walk_Up_y;
    float Walk_Left_x, Walk_Left_y;
    float Walk_Right_x, Walk_Right_y;

    void Start()
    {
        Walk_Down_x = ((y + 4.264f) / 0.1f) * speedUD;
        Walk_Down_y = (0.1f * x - 4.264f) * speedUD;
        Walk_Up_x = -((y + 4.264f) / 0.1f) * speedUD;
        Walk_Up_y = -(0.1f * x - 4.264f) * speedUD;
        Walk_Left_x = -((y + 6.02f) / 0.05f) * speedLR;
        Walk_Left_y = -(0.05f * x - 6.02f) * speedLR;
        Walk_Right_x = ((y + 6.02f) / 0.05f) * speedLR;
        Walk_Right_y = (0.05f * x - 6.02f) * speedLR;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Walk_Down_x, Walk_Down_y, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Walk_Up_x, Walk_Up_y, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Walk_Left_x, Walk_Left_y, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Walk_Right_x, Walk_Right_y, 0);
        }
    }

}
