using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combo_Test : MonoBehaviour
{
    volatile bool atkInputEnabled = false;
    volatile bool atkInputNow = false;

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

    //======기본 액션

    //공격
    public void ActionAttack() { }

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
