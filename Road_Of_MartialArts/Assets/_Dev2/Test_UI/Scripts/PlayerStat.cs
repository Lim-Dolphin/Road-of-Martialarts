using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float maxHP = 100f;
    private float currentHP;

    private float maxBattleGauge = 100f;
    private float currentBattleGauge;

    private int maxDash = 3;
    private int currentDash;

    private float dashRecoveryInterval = 5f; // 약진 게이지 자동회복 주기
    private float dashTimer = 0f; // 약진 게이지 자동회복 타이머

    private void Awake()
    {
        currentHP = maxHP;
        currentBattleGauge = 0f;
        currentDash = maxDash;
        TakeDamage(50f);
    }

    private void Update()
    {
        RecoverDashOverTime(); // 약진 게이지 자동 회복
    }

    // 능력치 가져오기
    public float GetHP() => currentHP;
    public float GetMaxHP() => maxHP;

    public float GetBattleGauge() => currentBattleGauge;
    public float GetMaxBattleGauge() => maxBattleGauge;

    public int GetDash() => currentDash;
    public int GetMaxDash() => maxDash;

    // 체력 관리
    public void TakeDamage(float damage)
    {
        currentHP = Mathf.Max(currentHP - damage, 0f); // 데미지가 음수가 될 수 없게끔 Mathf.Max() 사용
        UpdateHUD();

        if (currentHP <= 0)
            PlayerDeath();
    }

    private void PlayerDeath()
    {
        Debug.Log("플레이어 사망");
    }

    // 무예 게이지 관리
    public void GainBattleGauge(float amount) 
    {
        currentBattleGauge = Mathf.Min(currentBattleGauge + amount, maxBattleGauge); // 무술 게이지가 maxBattleGague를 넘어갈 수 없게끔 Mathf.Min() 사용
        UpdateHUD();
    }

    public bool UseBattleGauge(float amount)
    {
        if (currentBattleGauge >= amount)
        {
            currentBattleGauge -= amount;
            Debug.Log($"무예 스킬 사용, 남은 게이지: {currentBattleGauge}");
            return true;
        }
        else{
            Debug.Log("무술 게이지 부족!");
            return false;
        }
    }

    // 반격 성공 시
    public void SuccessParrying()
    {
        GainBattleGauge(30f); // 무술 게이지 회복
        UpdateHUD();

    }

    // 약진 게이지 관리
    public bool UseDash()
    {
        if (currentDash > 0)
        {
            currentDash--;
            Debug.Log($"약진 사용, 남은 횟수: {currentDash}");
            return true;
        }
        else{
            Debug.Log("약진 게이지 부족!");
            return false;
        }
    }
    
    // 약진 게이지 자동 회복
    public void RecoverDashOverTime()
    {
        if (currentDash < maxDash) // 약진 게이지가 MAX가 아니라면 dashTime(5초)만큼의 시간 뒤 회복
        {
            dashTimer += Time.deltaTime;
            if (dashTimer >= dashRecoveryInterval)
            {
                currentDash++;
                dashTimer = 0f;
                Debug.Log($"약진 자동 회복: {currentDash}");
            }
        }
    }

    // 반격 성공 시 회복
    public void RecoverDashOnParry()
    {
        if (currentDash < maxDash)
        {
            currentDash++;
            Debug.Log($"반격 성공! 약진 1칸 회복: {currentDash}");
        }
    }

        void UpdateHUD()
    {
        float hpRatio = currentHP / maxHP;
        float martialRatio = currentBattleGauge / maxBattleGauge;

        PlayerHUD.Instance.SetHP(hpRatio);
        PlayerHUD.Instance.SetMartialGauge(martialRatio);
    }
}