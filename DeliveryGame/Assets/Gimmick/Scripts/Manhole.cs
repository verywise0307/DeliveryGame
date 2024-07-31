using System.Collections;
using UnityEngine;

public class Manhole : MonoBehaviour
{   // Tag: hidebox is not defined 오류 -> 예나 PCmove스크립트 가져와서 그럼

    // 맨홀뚜껑- 위에서 점프 or 오래 서있으면 빠짐 => 택배 전부 파손
    // 오래의 기준이 뭐임? 몇초??
    // 일단 3초? 

    public float count = 0; //시간
    private bool On_Manhole = false; //맨홀에 닿았나?
    private bool coroutineRunning = false; // 코루틴 실행됨?

    void Update()
    {
        if (On_Manhole)
        {
            count += Time.deltaTime;
            if (count >= 3.0f && !coroutineRunning) //여기 점프 추가해야함
            {
                StartCoroutine(TagDisable());
            }
        }
    }

    IEnumerator TagDisable()
    {
        coroutineRunning = true; // 코루틴 실행중
        yield return null; // 반환 Start

        _Disable("Water", "습기 주의 물품");
        _Disable("Break", "파손 주의 물품");

        Debug.Log("모든 물품 파손");
        On_Manhole = false;
        count = 0;
        coroutineRunning = false; // 코루틴 종료
    }
    private void _Disable(string tag, string logMessage)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

        if (objectsWithTag.Length == 0)
        {
            Debug.Log($"{logMessage}이 없음");
        }
        else
        {
            foreach (GameObject obj in objectsWithTag)
            {
                obj.SetActive(false);
            }
            Debug.Log($"{logMessage} 파손");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //충돌 범위에 들어오면 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player 태그와 닿음");
            On_Manhole = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //충돌 범위를 벗어나면 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            On_Manhole = false;
            count = 0;
            coroutineRunning = false; // 코루틴 초기화
        }
    }
}
