using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manhole : MonoBehaviour
{   // ��Ȧ�Ѳ�- ������ ���� or ���� �������� ���� => �ù� ���� �ļ�
    // ������ ������ ����? ����??
    // �ϴ� 3��? 

    public float count = 0; //�ð�
    private bool On_Manhole = false; //��Ȧ�� ��ҳ�?

    void Update()
    {
        if (On_Manhole == true)
        {
            count += Time.deltaTime;
            Debug.Log(count);

            if (count >= 3)
            {
                List();
                On_Manhole = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //�浹 ������ ������ 
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player�±׿� ����");
            On_Manhole = true;
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //�浹 ������ ����� 
    {
        if (collision.gameObject.tag == "Player")
        {
            On_Manhole = false;
            count = 0;
        }
    }
    private void List() //�ļ� ����Ʈ
    {
        Debug.Log("�ù� ���� �ļ�");
    }
}