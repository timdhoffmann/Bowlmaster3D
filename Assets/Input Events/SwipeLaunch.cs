﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Ball))] // make sure there is a Ball componet present on the object.

public class SwipeLaunch : MonoBehaviour {
    private Ball ball;

    private float swipeStartTime, swipeEndTime;

    private Vector3 swipeStartPosition, swipeEndPosition;

    // Use this for initialization
    void Start () {
        ball = GetComponent<Ball>();       
    }

    public void SwipeStart() {
        // capture time and position of drag start.
        swipeStartTime = Time.time;
        swipeStartPosition = Input.mousePosition;
    }

    public void SwipeEnd() {
        // Capture duration and position.
        swipeEndTime = Time.time;
        swipeEndPosition = Input.mousePosition;

        float dragDuration = swipeEndTime - swipeStartTime;

        // translate x and y drag components into world space
        float launchSpeedX = (swipeEndPosition.x - swipeStartPosition.x) / dragDuration; // Speed = distance / time
        float launchSpeedZ = (swipeEndPosition.y - swipeStartPosition.y) / dragDuration;

        // Modify force vector to translate to game dimensions
        Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
  
        // Launch ball.
        Debug.Log("drag duration at launch = " + dragDuration);
        Debug.Log("Velocity at launch = " + launchVelocity);
        ball.Launch (launchVelocity);
}

    // Update is called once per frame
    void Update () {
		
	}
}
