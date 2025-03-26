using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldPCamera : MonoBehaviour
{
    public Transform player;
    public float yOffset;
    public float zOffset;
    
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z - zOffset);
    }
}
