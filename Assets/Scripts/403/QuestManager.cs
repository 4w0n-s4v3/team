using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public Dictionary<int, QuestData> questList;
    public List<string> talkData;
    public Sprite[] images;
    string[] potionName = {"체력 포션", "스테미나 포션", "신속 포션", "구속 포션", "독 포션" ,"힘 포션", "화염 포션", "냉기 포션", "폭발 포션", "번개 포션", "발광 포션", "재생 포션", "보드카"};
    readonly int[] costList = { 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200 };

    void Start()
    {
        talkData.Clear();
        talkData.Add("오늘 주문은..");
        questId = 0;
        questList = new Dictionary<int, QuestData>();
        int questCount = Random.Range(5, 8);
        for (int i = 0; i < questCount; i++) {
            QuestAdd();
        }

        talkData.Add("이 정도네요!");
    }


    // Update is called once per frame
    void Update()
    {
        if (false) { //낮밤 바꾸는 코드 있으면 조건문에좀
            int questCount = Random.Range(5, 8);
                for (int i = 0; i < questCount; i++) {
                QuestAdd();
            }
        }
    }

    void QuestAdd() {
        int potid = Random.Range(1, 14);
        int count = Random.Range(1, 11);
        int cost = costList[potid-1] * count;
        questId++;
        questList.Add(questId, new QuestData(potid, count, cost));
        talkData.Add(potionName[potid-1] + " " + count + "개랑, ");
    }
}
