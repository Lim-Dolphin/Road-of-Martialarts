using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float attackRange = 2f;    
    public float attackDamage = 10f;
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= attackRange)
        {
            Attack();
        }
    }
    
    public void Attack()
    {
        Debug.Log("Enemy 공격 시도"); // 추가
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= attackRange)
        {
            Move move = player.GetComponent<Move>();
            if (move != null)
            {
                move.OnHit(attackDamage); // Move에서 체력 처리 및 피격 트리거
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
