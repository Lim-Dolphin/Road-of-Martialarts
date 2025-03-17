using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    Rigidbody rb;

    Vector3 moveVec;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        rb.velocity = moveVec * speed;
    }
}
