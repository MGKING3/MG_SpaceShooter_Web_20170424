using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMover : MonoBehaviour {
    public float moveSpeed;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.velocity = transform.forward * moveSpeed;
    }
}
