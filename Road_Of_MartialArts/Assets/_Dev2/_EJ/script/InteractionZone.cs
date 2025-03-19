using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 추가

public class InteractionZone : MonoBehaviour
{
    public GameObject interactionUI; // UI 패널
    private bool isPlayerNearby = false; // 플레이어가 근처에 있는지 체크

    private void Start()
    {
        interactionUI.SetActive(false); // 게임 시작 시 UI 창 숨기기
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            OpenUI();
        }
    }

    void OpenUI()
    {
        interactionUI.SetActive(true); // UI 창 활성화
        Time.timeScale = 0f; // 플레이어 움직임 방지
    }

    public void CloseUI()
    {
        interactionUI.SetActive(false); // UI 창 비활성화
        Time.timeScale = 1f; // 다시 움직일 수 있도록 복구
    }

    public void EnterScene()
    {
        Time.timeScale = 1f; // 씬 이동 전 시간 복구
        SceneManager.LoadScene("EJ_Map"); // 이동할 씬 이름 입력
    }
}