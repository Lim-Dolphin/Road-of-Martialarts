using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private PlayerStats playerStats;
    public float moveSpeed = 5f;
    private bool canMove = true; // 이동 가능 여부

    private Rigidbody rb;
    private Vector3 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerStats = GetComponent<PlayerStats>(); // PlayerStats 컴포넌트 연결
    }

    void Update()
    {
        if (!canMove) return; // 이동 불가능하면 return

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(-moveX, 0, -moveZ).normalized * moveSpeed;

        if (Input.GetKeyDown(KeyCode.F))
        {
            playerStats.UseDash();
        }
    }

    void FixedUpdate()
    {
        if (canMove)
            rb.MovePosition(rb.position + moveInput * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Enemy"))
    {
        playerStats.TakeDamage(10f);
    }
}
    public void SetMovement(bool isMovable)
    {
        canMove = isMovable; // 이동 가능 여부 설정
    }
}