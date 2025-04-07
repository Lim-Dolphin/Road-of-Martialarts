using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player_Combo_Test : MonoBehaviour
{
    volatile bool atkInputEnabled = false;
    volatile bool atkInputNow = false;
    private Animator animator;

    //Animation State
    public readonly static int ANISTS_Idle = Animator.StringToHash("Base Layer.IDLE");
    public readonly static int ANISTS_Run = Animator.StringToHash("Base Layer.Run");
    public readonly static int ANISTS_Form = Animator.StringToHash("Base Layer.Combo_System.Form");
    //콤보 공격 카운트
    private int Attack_cnt;

    //세 여부
    private bool Formed;

    //ActionEvent
    public event Action ActionEvent = null;
    public void Start()
    {
        animator = GetComponent<Animator>();
        Attack_cnt = 0;
        Formed = false;
    }

    //애니메이션용 이벤트 코드
    public void EnableAttackInput() {
        atkInputEnabled = true;
    }
    public void NextAction() {
        if (ActionEvent != null)
        {
            Debug.Log("Play Combo Animation");
            ActionEvent.Invoke();
            ActionEvent = null;
        }
        else
        {
            Attack_cnt = 0;
        }
    }

    //세 전용 애니메이션 이벤트
    public void DisableForm()
    {
        Formed = false;
        Debug.Log("off form!");
    }

    public void PlayAnimation(string parameter, int actNum) 
    {
        animator.SetFloat(parameter, actNum);
    }

    //======기본 액션

    //공격
    public void ActionAttack() {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash == ANISTS_Idle ||
            stateInfo.fullPathHash == ANISTS_Run)
        {
            playAttack();
        }
        else
        {
            if (atkInputEnabled) 
            {
                Debug.Log("Combo!" + Attack_cnt);
                atkInputEnabled = false;
                if(ActionEvent == null)
                {
                    if (Attack_cnt < 4)
                    {
                        ActionEvent += playAttack;
                    }
                    else
                    {
                        ActionEvent += EndAttackCombo;
                    }
                }    
            }
        }
    }

    private void playAttack()
    {
        animator.SetTrigger("Attack");
        if (Formed && Attack_cnt == 3)
        {
            Formed = false;
            Attack_cnt = 4;
        }
        PlayAnimation("Attack_Blend", Attack_cnt);
        Attack_cnt++;
    }

    private void EndAttackCombo()
    {
        Attack_cnt = 0;
    }

    //세
    public void ActionForm() {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash != ANISTS_Form)
        {
            Formed = true;

            if (Attack_cnt <= 2)
            {
                playForm();
                EndAttackCombo();
            }
        }
    }

    private void playForm()
    {
        animator.SetTrigger("Form");
    }

    //궁극기
    public void ActionUltimate() { }

    //방어
    public void ActtionGuard() { }

    //잡기(던지기)
    public void ActionThrow() { }

    //잡기(위치바꾸기)
    public void ActionChangePosition() { }
}
