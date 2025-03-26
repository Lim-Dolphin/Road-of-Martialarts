using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true; // 이동 가능 여부

    private Rigidbody rb;
    private Vector3 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!canMove) return; // 이동 불가능하면 return

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(moveX, 0, moveZ).normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        if (canMove)
            rb.MovePosition(rb.position + moveInput * Time.fixedDeltaTime);
    }

    public void SetMovement(bool isMovable)
    {
        canMove = isMovable; // 이동 가능 여부 설정
    }
}