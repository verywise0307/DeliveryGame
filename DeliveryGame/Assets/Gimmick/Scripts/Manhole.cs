using System.Collections;
using UnityEngine;

public class Manhole : MonoBehaviour
{   // Tag: hidebox is not defined ���� -> ���� PCmove��ũ��Ʈ �����ͼ� �׷�

    // ��Ȧ�Ѳ�- ������ ���� or ���� �������� ���� => �ù� ���� �ļ�
    // ������ ������ ����? ����??
    // �ϴ� 3��? 

    public float count = 0; //�ð�
    private bool On_Manhole = false; //��Ȧ�� ��ҳ�?
    private bool coroutineRunning = false; // �ڷ�ƾ �����?

    void Update()
    {
        if (On_Manhole)
        {
            count += Time.deltaTime;
            if (count >= 3.0f && !coroutineRunning) //���� ���� �߰��ؾ���
            {
                StartCoroutine(TagDisable());
            }
        }
    }

    IEnumerator TagDisable()
    {
        coroutineRunning = true; // �ڷ�ƾ ������
        yield return null; // ��ȯ Start

        _Disable("Water", "���� ���� ��ǰ");
        _Disable("Break", "�ļ� ���� ��ǰ");

        Debug.Log("��� ��ǰ �ļ�");
        On_Manhole = false;
        count = 0;
        coroutineRunning = false; // �ڷ�ƾ ����
    }
    private void _Disable(string tag, string logMessage)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

        if (objectsWithTag.Length == 0)
        {
            Debug.Log($"{logMessage}�� ����");
        }
        else
        {
            foreach (GameObject obj in objectsWithTag)
            {
                obj.SetActive(false);
            }
            Debug.Log($"{logMessage} �ļ�");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //�浹 ������ ������ 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player �±׿� ����");
            On_Manhole = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //�浹 ������ ����� 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            On_Manhole = false;
            count = 0;
            coroutineRunning = false; // �ڷ�ƾ �ʱ�ȭ
        }
    }
}
