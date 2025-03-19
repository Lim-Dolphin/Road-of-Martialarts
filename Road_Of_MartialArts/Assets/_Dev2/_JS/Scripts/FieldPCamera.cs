using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldPCamera : MonoBehaviour
{
    public Transform player;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z-35);
    }
}
