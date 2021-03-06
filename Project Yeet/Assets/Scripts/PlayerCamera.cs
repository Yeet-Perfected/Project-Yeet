﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Variables
    public Transform player;
    public float smoothTime = 0.3f;

    public float height = 3f;
    public float distance = 7f;

    private Vector3 velocity = Vector3.zero;

    // Methods
    void Update()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.y = player.position.y + height;
        pos.z = player.position.z - distance;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);
    }
}
