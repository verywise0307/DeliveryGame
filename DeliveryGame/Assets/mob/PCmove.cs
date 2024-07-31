using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMove : MonoBehaviour
{
    public float moveSpeed = 5f;        // 이동 속도
    public float jumpForce = 5f;      // 점프 힘
    public string groundTag = "ground"; // 땅의 태그
    public string boxTag = "hidebox"; // 숨기박스의 태그

    private Rigidbody2D rb;            // 캐릭터의 Rigidbody2D 컴포넌트
    private bool isGrounded;          // 캐릭터가 땅에 닿아 있는지 여부
    public bool isHidden;          // 캐릭터가 상자에 숨어 있는지 여부

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D 컴포넌트 가져오기
    }

    private void Update()
    {
        // 이동 입력 받기
        float moveInput = Input.GetAxis("Horizontal");  // 방향키 입력 (좌우)

        // 이동 벡터 생성
        Vector2 movement = new Vector2(moveInput, 0f) * moveSpeed;

        // 캐릭터의 위치를 이동 벡터만큼 이동시키기
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        // 점프 입력 처리
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(isHidden)
        {
            //Debug.Log("숨음");
        }
        else
        {
            //Debug.Log("드러남");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 땅과 충돌할 때 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true;
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 땅과 충돌이 끝날 때 isGrounded를 false로 설정
        if (collision.gameObject.CompareTag(boxTag))
        {
            isGrounded = false;
        }

        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 상자에 숨을 때 isHidden를 true로 설정
        if (other.gameObject.CompareTag(boxTag))
        {
            isHidden = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // 상자에 숨을 때 isHidden를 false로 설정
        if (other.gameObject.CompareTag(boxTag))
        {
            isHidden = false;
        }
    }
}