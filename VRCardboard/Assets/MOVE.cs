using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class MOVE : MonoBehaviour
{
    public InputActionProperty joystick;
    private bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        // var js = new Vector2();
        var js = joystick.action.ReadValue<Vector2>();
        if (joystick.action.triggered)
            Debug.Log(js);

        float x = Math.Abs(js.x);
        float y = Math.Abs(js.y);

        bool up = false, down = false, right = false, left = false;

        if (x + y < 0.1)
        {
            isTriggered = false;
        }

        if (isTriggered) { return; }

        if (x > y && x > 0.3)
        {
            if (js.x > 0)
            {
                right = true;
                Debug.Log("right");

            }
            else
            {
                left = true;
                Debug.Log("left");

            }
        }
        else if (y > x && y > 0.3)
        {
            if (js.y > 0)
            {
                up = true;
                Debug.Log("up");

            }
            else
            {
                down = true;
                Debug.Log("down");

            }
        }

        if (up || down || left || right)
        {
            isTriggered = true;
        }
        
    }
}
