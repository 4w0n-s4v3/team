using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public int Questnum;
    Dictionary<int, QuestData> questlist;
    GameObject tst;
    // Start is called before the first frame update
    void Start()
    {
        tst = GameObject.Find("npc");
    }

    // Update is called once per frame
    void Update()
    {
        //여기에 퀘스트 정보 받아오는 코드 입력
        questlist = tst.GetComponent<QuestManager>().questList;
        int potid = questlist[Questnum].PotionId;
        int count = questlist[Questnum].Count;
        int reward = questlist[Questnum].Cost;
        if(Input.GetMouseButton(0)) {
            //여기에 인벤토리에 필요한 아이템 있는지 확인하는 코드 입력
            //여기에 인벤토리에서 아이템 빼는 코드 입력
            //여기에 돈주는 코드 입력
            //여기에 퀘스트 제거 (혹은 취소선) 하는 코드 입력
        }
    }
}
