using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotater : MonoBehaviour {
    public float rotateValue;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.angularVelocity = Random.insideUnitSphere * rotateValue;
    }
}
