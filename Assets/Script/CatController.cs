using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 300.0f;
    float walkForce = 5.0f;
    float maxWalkSpeed = 1.0f;

    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
            isGrounded = true;
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            animator.SetTrigger("Jump");
        }


        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        if (speedx < this.maxWalkSpeed)
            this.rigid2D.AddForce(transform.right * key * this.walkForce);

        // 움직이는 방향에 따라 반전
        if (key != 0)
            transform.localScale = new Vector3(key, 1, 1);

        // 플레이어 속도에 맞춰 애니메이션 속도 변경
        this.animator.speed = speedx / 2.0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("도착!!");
        SceneManager.LoadScene("ClearScene");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("구름 이랑 충돌했니?");
        isGrounded = false;
    }
}
