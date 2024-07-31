using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobmove : MonoBehaviour
{
    int randNum; //������ �ð�
    float time; //������ �ð� ����
    int randDir; //������ ���� �̱�
    float dir; //������ ����
    float chasingDir; //�Ѵ� ����
    public string groundTag = "ground"; // ���� �±�

    public GameObject PC;
    private bool isChasing; // PC�� ���� ������ ����
    private bool isfalling; // PC�� ���� ������ ����
    private PCMove pcMoveScript; // PCMove ��ũ��Ʈ�� ������ ����

    public float moveSpeed = 0.5f;        // �̵� �ӵ�
    public float chasingmoveSpeed = 1f;        // �̵� �ӵ�

    private Rigidbody2D rb;            // ���� Rigidbody2D ������Ʈ
    private SpriteRenderer spriteRenderer;  // ��������Ʈ�� SpriteRenderer ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        randNum = Random.Range(1, 3);
        randDir = Random.Range(0, 2);

        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>();  // SpriteRenderer ������Ʈ ��������

        // PCMove ��ũ��Ʈ�� ��������.
        pcMoveScript = PC.GetComponent<PCMove>();

        time = 0;
        if(randDir == 0)
        {
            dir = -1.0f;
            spriteRenderer.flipX = false;
        }
        else
        {
            dir = 1.0f;
            spriteRenderer.flipX = true;
        }

        isChasing = false; // ó������ �������� ����
        isfalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(time);
        time += Time.deltaTime;

        // PC���� �Ÿ� ���
        float distancePC = transform.position.x - PC.transform.position.x;

        if(((distancePC <= 0 && distancePC > -5) && dir > 0) || ((distancePC>=0 && distancePC < 5) && dir < 0)) //������ ����
        {
            if(pcMoveScript.isHidden)
            {
                Debug.Log("�ѱ�");
                isChasing = true;
                chasingDir = dir;
            }
            
        }
        else
        {
            Debug.Log("���ѱ�");
            isChasing =false;
            isfalling = true;
        }


        // �̵� ���� ����
        Vector2 movement = new Vector2(dir, 0f) * moveSpeed;

        // ĳ������ ��ġ�� �̵� ���͸�ŭ �̵���Ű��
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        if (time > randNum && !isChasing) //������ �ð��� ������ �ʱ�ȭ
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            dir *= -1;
            time = 0;
            randNum = Random.Range(1, 3);
        }

        // (isChasing)
        //{
        //    dir = chasingDir;
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ������ ����� �� ���� �ٲٱ�
        if (other.gameObject.CompareTag(groundTag))
        {
            isChasing=false;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            dir *= -1;
        }
    }
}
