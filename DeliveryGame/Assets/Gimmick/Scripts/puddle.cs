using System.Collections;
using UnityEngine;

public class puddle : MonoBehaviour
{ // ��������- ������ �������� �ù� �ļ�


    IEnumerator TagDisable()
    {
        yield return null; // ��ȯ Start

        GameObject[] Water_objectsWithTag = GameObject.FindGameObjectsWithTag("Water");

        if (Water_objectsWithTag.Length == 0)
        {
            Debug.Log("���� ���� ��ǰ�� ����");
        }
        else
        {
            foreach (GameObject obj in Water_objectsWithTag)
            {
                obj.SetActive(false);
                Debug.Log("���� ���� ��ǰ �ļ�");
            }
        }
        yield break;
    }


    private void OnTriggerEnter2D(Collider2D collision) //�浹 ������ ������ 
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player�±׿� ����");
            StartCoroutine(TagDisable());
        }
    }
}
