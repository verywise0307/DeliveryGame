using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notice : MonoBehaviour
{
    //근처에 가서 f누르면 상호작용
    //상호작용 -> 아무 화면 띄우기
    //x버튼 또는 esc 누르면 닫힘

    public GameObject notice_image;
    bool On_Notice = false;
    bool now_Visible=false;

    private void Update()
    {
        Interaction();

    }
    private void Interaction()
    {
        if (On_Notice)
        {
            if (Input.GetKeyDown(KeyCode.F) && !now_Visible) // `Input.GetKeyDown`으로 수정하여 키가 눌린 순간만 감지
            {
                notice_image.SetActive(true); // notice_image를 활성화
                now_Visible = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)&& now_Visible) // ESC 키로 알림 이미지 끄기
        {
            notice_image.SetActive(false);
            now_Visible = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            On_Notice = true;
            Debug.Log("게시판과 닿음");
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //충돌 범위를 벗어나면 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            On_Notice = false;

            if(now_Visible==true)
            {
                notice_image.SetActive(false);
                now_Visible = false;
            }
        }
    }
    public void OnClick()
    {
        notice_image.SetActive(false);
        now_Visible = false;
    }
}
