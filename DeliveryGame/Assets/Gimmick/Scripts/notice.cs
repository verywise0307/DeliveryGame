using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notice : MonoBehaviour
{
    //��ó�� ���� f������ ��ȣ�ۿ�
    //��ȣ�ۿ� -> �ƹ� ȭ�� ����
    //x��ư �Ǵ� esc ������ ����

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
            if (Input.GetKeyDown(KeyCode.F) && !now_Visible) // `Input.GetKeyDown`���� �����Ͽ� Ű�� ���� ������ ����
            {
                notice_image.SetActive(true); // notice_image�� Ȱ��ȭ
                now_Visible = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)&& now_Visible) // ESC Ű�� �˸� �̹��� ����
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
            Debug.Log("�Խ��ǰ� ����");
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //�浹 ������ ����� 
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
