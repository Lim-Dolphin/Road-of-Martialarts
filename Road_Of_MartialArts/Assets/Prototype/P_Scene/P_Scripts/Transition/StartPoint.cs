using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPoint : MonoBehaviour
{
    [SerializeField]
    private string previousSceneName; // 이동한 맵의 이름과 일치하는지 확인

    Move_JS player;
    CameraMove_JS cam;

    void Start()
    {
         player = Move_JS.instance;
         cam = CameraMove_JS.instance;

        if (SceneManager.GetActiveScene().name != "JS_Overworld") // 오버월드 아니면 활성화
        {
            // 필드에선 필드 카메라, 캐릭터 활성화
            player.gameObject.SetActive(true);
            cam.gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "JS_Overworld") // 오버월드면 비활성화
        {
            // 필드에선 필드 카메라, 캐릭터 활성화
            player.gameObject.SetActive(false);
            cam.gameObject.SetActive(false);
        }

        if (previousSceneName == player.currentSceneName)
        {   
            // 캐릭터컨트롤러가 활성화 되면 위치이동이 안되서 비활성화함
            CharacterController cc = player.GetComponent<CharacterController>(); 
            cc.enabled = false; // 임시로 비활성화
            player.transform.position = transform.position; // 캐릭터 이동
            cam.SnapToTarget();                             // 카메라 이동
            cc.enabled = true;  // 다시 활성화
        }
    }
}
