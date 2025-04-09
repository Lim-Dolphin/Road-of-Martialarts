using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyStatus enemyStatus; // 적 스테이터스 참조
    private float currentHP;
    private float damageValue; // 받는 데미지 수치
    void Start()
    {
        enemyStatus = GetComponent<EnemyStatus>();
    }

    private void GetDamage(float damageVal)
    {
        damageValue = damageVal;
        enemyStatus.SetHP(10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            GetDamage(-10f);
        }
    }
}
