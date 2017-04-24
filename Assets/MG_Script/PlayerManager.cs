﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerManager : MonoBehaviour {
    public float moveSpeed;
    public Boundary canMoveArea;
    public float rotateValue;
    private float horizontalValue;
    private float verticalValue;
    private Vector3 moveDirection;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalValue, 0.0F, verticalValue);
        rb.velocity = moveDirection * moveSpeed;
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, canMoveArea.xMin, canMoveArea.xMax),
            0.0F,
            Mathf.Clamp(rb.position.z, canMoveArea.zMin, canMoveArea.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0F, 0.0F, -rb.velocity.x * rotateValue);
    }
}
