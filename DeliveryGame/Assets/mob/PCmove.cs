using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMove : MonoBehaviour
{
    public float moveSpeed = 5f;        // �̵� �ӵ�
    public float jumpForce = 5f;      // ���� ��
    public string groundTag = "ground"; // ���� �±�
    public string boxTag = "hidebox"; // ����ڽ��� �±�

    private Rigidbody2D rb;            // ĳ������ Rigidbody2D ������Ʈ
    private bool isGrounded;          // ĳ���Ͱ� ���� ��� �ִ��� ����
    public bool isHidden;          // ĳ���Ͱ� ���ڿ� ���� �ִ��� ����

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D ������Ʈ ��������
    }

    private void Update()
    {
        // �̵� �Է� �ޱ�
        float moveInput = Input.GetAxis("Horizontal");  // ����Ű �Է� (�¿�)

        // �̵� ���� ����
        Vector2 movement = new Vector2(moveInput, 0f) * moveSpeed;

        // ĳ������ ��ġ�� �̵� ���͸�ŭ �̵���Ű��
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        // ���� �Է� ó��
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(isHidden)
        {
            //Debug.Log("����");
        }
        else
        {
            //Debug.Log("�巯��");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� �浹�� �� isGrounded�� true�� ����
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true;
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ���� �浹�� ���� �� isGrounded�� false�� ����
        if (collision.gameObject.CompareTag(boxTag))
        {
            isGrounded = false;
        }

        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // ���ڿ� ���� �� isHidden�� true�� ����
        if (other.gameObject.CompareTag(boxTag))
        {
            isHidden = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // ���ڿ� ���� �� isHidden�� false�� ����
        if (other.gameObject.CompareTag(boxTag))
        {
            isHidden = false;
        }
    }
}