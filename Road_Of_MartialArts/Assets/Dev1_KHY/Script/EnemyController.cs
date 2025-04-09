using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void OnHit(float damage)
    {
        currentHealth -= damage;
        Debug.Log("적이 피격됨! 현재 체력: " + currentHealth);

        // 피격 애니메이션 트리거
        if (animator != null)
        {
            animator.SetTrigger("");
        }

    }

}

