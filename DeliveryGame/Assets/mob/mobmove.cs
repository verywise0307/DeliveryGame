using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobmove : MonoBehaviour
{
    int randNum; //움직일 시간
    float time; //움직인 시간 측정
    int randDir; //움직일 방향 뽑기
    float dir; //움직일 방향
    float chasingDir; //쫓는 방향
    public string groundTag = "ground"; // 땅의 태그

    public GameObject PC;
    private bool isChasing; // PC를 추적 중인지 여부
    private bool isfalling; // PC를 추적 중인지 여부
    private PCMove pcMoveScript; // PCMove 스크립트를 가져올 변수

    public float moveSpeed = 0.5f;        // 이동 속도
    public float chasingmoveSpeed = 1f;        // 이동 속도

    private Rigidbody2D rb;            // 몹의 Rigidbody2D 컴포넌트
    private SpriteRenderer spriteRenderer;  // 스프라이트의 SpriteRenderer 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        randNum = Random.Range(1, 3);
        randDir = Random.Range(0, 2);

        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();  // SpriteRenderer 컴포넌트 가져오기

        // PCMove 스크립트를 가져오기.
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

        isChasing = false; // 처음에는 추적하지 않음
        isfalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(time);
        time += Time.deltaTime;

        // PC와의 거리 계산
        float distancePC = transform.position.x - PC.transform.position.x;

        if(((distancePC <= 0 && distancePC > -5) && dir > 0) || ((distancePC>=0 && distancePC < 5) && dir < 0)) //쫓을지 결정
        {
            if(pcMoveScript.isHidden)
            {
                Debug.Log("쫓기");
                isChasing = true;
                chasingDir = dir;
            }
            
        }
        else
        {
            Debug.Log("안쫓기");
            isChasing =false;
            isfalling = true;
        }


        // 이동 벡터 생성
        Vector2 movement = new Vector2(dir, 0f) * moveSpeed;

        // 캐릭터의 위치를 이동 벡터만큼 이동시키기
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        if (time > randNum && !isChasing) //임의의 시간이 지나면 초기화
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
        // 땅에서 벗어났을 때 방향 바꾸기
        if (other.gameObject.CompareTag(groundTag))
        {
            isChasing=false;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            dir *= -1;
        }
    }
}
