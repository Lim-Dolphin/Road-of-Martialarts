using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField]
    private string startPoint; // 맵이 이동, 플레이어가 시작될 위치

    private Move_JS player;
    private CameraMove_JS cam;
    
    void Start()
    {
        player = FindObjectOfType<Move_JS>();
        cam = FindObjectOfType<CameraMove_JS>();

        if(startPoint == player.currentSceneName)
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false; // 임시로 비활성화
            player.transform.position = transform.position;
            cam.SnapToTarget();
            cc.enabled = true;  // 다시 활성화
        }
    }

    void Update()
    {
        
    }
}
