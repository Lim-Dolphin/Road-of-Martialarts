using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static PlayerHUD Instance { get; private set; }
    public Image playerPortrait;     // 캐릭터 이미지
    public Image hpBar;              // HP 바 (초록색)
    public Image BattleGauge;       // 무예 게이지 (노란색)

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

    // HP 업데이트: 0 ~ 1 값
    public void SetHP(float normalizedValue)
    {
        if (hpBar != null)
            hpBar.fillAmount = Mathf.Clamp01(normalizedValue);
    }

    // 무예 게이지 업데이트: 0 ~ 1 값
    public void SetMartialGauge(float normalizedValue)
    {
        if (BattleGauge != null)
            BattleGauge.fillAmount = Mathf.Clamp01(normalizedValue);
    }
}