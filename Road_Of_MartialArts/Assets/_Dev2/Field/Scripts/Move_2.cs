using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Move_2 : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    Rigidbody rb;

    Vector3 moveVec;

    public float tiltAngle = -34.48f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        Quaternion tiltRotation = Quaternion.Euler(tiltAngle, 0, 0);

        rb.velocity = tiltRotation * (moveVec * speed);
    }
}
