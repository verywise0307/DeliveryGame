using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manhole : MonoBehaviour
{   // 맨홀뚜껑- 위에서 점프 or 오래 서있으면 빠짐 => 택배 전부 파손
    // 오래의 기준이 뭐임? 몇초??
    // 일단 3초? 

    public float count = 0; //시간
    private bool On_Manhole = false; //멘홀에 닿았나?

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
    private void OnTriggerEnter2D(Collider2D collision) //충돌 범위에 들어오면 
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player태그와 닿음");
            On_Manhole = true;
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //충돌 범위를 벗어나면 
    {
        if (collision.gameObject.tag == "Player")
        {
            On_Manhole = false;
            count = 0;
        }
    }
    private void List() //파손 리스트
    {
        Debug.Log("택배 전부 파손");
    }
}