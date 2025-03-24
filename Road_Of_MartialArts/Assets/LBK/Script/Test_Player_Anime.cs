using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player_Anime : MonoBehaviour
{

    private Animator animator;
    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("IsRunning", true);
            transform.localScale = new Vector3(-1, 1, 1);

        }

        if(Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("IsRunning", false);
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("IsRunning", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
