using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combo_Test : MonoBehaviour
{
    volatile bool atkInputEnabled = false;
    volatile bool atkInputNow = false;
    private Animator animator;

    //콤보 공격 카운트
    private int Attack_cnt;

    public void Start()
    {
        animator = GetComponent<Animator>();
        Attack_cnt = 0;
    }

    //애니메이션용 이벤트 코드
    public void EnableAttackInput() {
        atkInputEnabled = true;
    }
    public void SetNextAttack(string name) {
        if (atkInputNow == true)
        {
            atkInputNow = false;
        }
    }

    public void PlayAnimation(string parameter, int actNum) 
    {
        animator.SetFloat(parameter, actNum);
    }

    //======기본 액션

    //공격
    public void ActionAttack() {
        animator.SetTrigger("Attack");
        PlayAnimation("Attack_blend", Attack_cnt);
        Attack_cnt++;

        if (Attack_cnt >= 4) Attack_cnt = 0;
    }

    //세
    public void ActionForm() { }

    //궁극기
    public void ActionUltimate() { }

    //방어
    public void ActtionGuard() { }

    //잡기(던지기)
    public void ActionThrow() { }

    //잡기(위치바꾸기)
    public void ActionChangePosition() { }
}
