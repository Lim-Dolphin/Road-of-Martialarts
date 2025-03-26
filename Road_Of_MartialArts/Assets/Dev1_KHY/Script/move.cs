using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float jumpButtonGracePeriod;

    private CharacterController characterController;
    private float ySpeed; // 현재 적용받는 y 속도값
    private float originalStepOffset; // CharacterController의 StepOffset 설정값
    private float? lastGroundedTime; //마지막 땅 접지 시간, float? (Nullable<float>를 사용하여 null 할당)
    private float? jumpButtonPressedTime; //점프 버튼 누른 시간
    

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 

        Vector3 movementDirection = new Vector3(horizontalInput*-1, 0, verticalInput*-1);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed; //정규화 전 대각선 문제 해결을 위한 크기 제한
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime; //캐릭터 점프 시 중력에 의한 속도 감소

        if (characterController.isGrounded){
            lastGroundedTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0)){
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonPressedTime){
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.8f;
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;

                lastGroundedTime = null;
                jumpButtonPressedTime = null;
            }
        } else {
            characterController.stepOffset = 0;
        }

        //점프 속도 포함한 velocity 계산
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);
    }
}
