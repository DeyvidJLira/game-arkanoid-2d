﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHorizontalPhysicMovementBehaviour : MonoBehaviour
{
    public float speed = 0.3f;
    //public float limit = 7.40f;

    // Update is called once per frame
    void Update() {
        Vector2 currentPosition = transform.position;

        if (Input.GetKey(KeyCode.RightArrow)) {
            currentPosition.x += speed;
            /*if (currentPosition.x > limit)
                currentPosition.x = limit;*/
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            currentPosition.x -= speed;
            /*if (currentPosition.x < (-1 * limit))
                currentPosition.x = (-1 * limit);*/
        }

        GetComponent<Rigidbody2D>().MovePosition(currentPosition);
    }
}
