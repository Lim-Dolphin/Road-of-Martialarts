using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextPointZ : MonoBehaviour
{
    [SerializeField]
    private string transferSceneName;

    public Transform target;

    private Move_JS player;
    private CameraMove_JS cam;

    void Start()
    {
        player = FindObjectOfType<Move_JS>();
        cam = FindObjectOfType<CameraMove_JS>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false; // 임시로 비활성화
            Vector3 newPos = new Vector3(other.transform.position.x, target.transform.position.y, target.transform.position.z);
            player.transform.position = newPos;
            cam.SnapToTarget();
            cc.enabled = true;  // 다시 활성화
        }
    }
}
