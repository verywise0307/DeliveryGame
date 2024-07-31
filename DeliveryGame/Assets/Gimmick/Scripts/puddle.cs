using System.Collections;
using UnityEngine;

public class puddle : MonoBehaviour
{ // 물웅덩이- 닿으면 습기주의 택배 파손


    IEnumerator TagDisable()
    {
        yield return null; // 반환 Start

        GameObject[] Water_objectsWithTag = GameObject.FindGameObjectsWithTag("Water");

        if (Water_objectsWithTag.Length == 0)
        {
            Debug.Log("습기 주의 물품이 없음");
        }
        else
        {
            foreach (GameObject obj in Water_objectsWithTag)
            {
                obj.SetActive(false);
                Debug.Log("습기 주의 물품 파손");
            }
        }
        yield break;
    }


    private void OnTriggerEnter2D(Collider2D collision) //충돌 범위에 들어오면 
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player태그와 닿음");
            StartCoroutine(TagDisable());
        }
    }
}
