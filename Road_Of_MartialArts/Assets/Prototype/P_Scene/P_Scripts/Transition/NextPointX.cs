using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextPointX : MonoBehaviour
{
    public Transform target;

    private Move_JS player;
    private CameraMove_JS cam;

    private void Start()
    {
        player = Move_JS.instance;
        cam = CameraMove_JS.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false; // 임시로 비활성화
            Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, other.transform.position.z);
            player.transform.position = newPos;
            cam.SnapToTarget();
            cc.enabled = true;  // 다시 활성화
        }
    }
}
