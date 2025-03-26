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
    private float ySpeed; // ���� ����޴� y �ӵ���
    private float originalStepOffset; // CharacterController�� StepOffset ������
    private float? lastGroundedTime; //������ �� ���� �ð�, float? (Nullable<float>�� ����Ͽ� null �Ҵ�)
    private float? jumpButtonPressedTime; //���� ��ư ���� �ð�
    

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
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed; //����ȭ �� �밢�� ���� �ذ��� ���� ũ�� ����
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime; //ĳ���� ���� �� �߷¿� ���� �ӵ� ����

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

        //���� �ӵ� ������ velocity ���
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);
    }
}
