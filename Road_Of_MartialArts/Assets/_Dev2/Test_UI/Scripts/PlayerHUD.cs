using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static PlayerHUD Instance { get; private set; }
    [SerializeField] private Image playerPortrait; // 캐릭터 초상화
    [SerializeField] private Image hpBar; // 체력바
    [SerializeField] private Image battleGauge; // 무예게이지
    [SerializeField] private Image[] dashSlots; // 약진 슬롯 배열
    private float currentHPFill = 1f; // 현재 보여지는 fillAmount
    private float realHPFill = 1f;  // 실제 체력 비율
    [SerializeField] private float smoothSpeed = 5f; // 부드럽게 줄어드는 속도
    void Awake()
    {
        // 싱글톤 초기화
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬 이동 시 유지
    }

    private void Update()
    {
        // 실제 보여지는 fillAmount를 부드럽게 이동
        currentHPFill = Mathf.Lerp(currentHPFill, realHPFill, Time.deltaTime * smoothSpeed);
        hpBar.fillAmount = currentHPFill;
    }

    // HP 업데이트: 0 ~ 1 값
    public void SetHP(float normalizedValue)
    {
        if (hpBar != null)
        {
            realHPFill = Mathf.Clamp01(normalizedValue);
        }
    }

    // 무예 게이지 업데이트: 0 ~ 1 값
    public void SetBattleGauge(float normalizedValue)
    {
        if (battleGauge != null)
            battleGauge.fillAmount = Mathf.Clamp01(normalizedValue);
    }

    public void SetDashGauge(int currentDash)
    {
        currentDash = Mathf.Clamp(currentDash, 0, dashSlots.Length);

        for (int i = 0; i < dashSlots.Length; i++)
        {
            if (i < currentDash)
            dashSlots[i].enabled = true;
            else
            dashSlots[i].enabled = false;
        }
    }

}