
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    public float attackDamage = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("플레이어가 적을 공격!");

            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.OnHit(attackDamage);
            }
        }
    }
}
