using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    public Dictionary<int, QuestData> questList;
    int[] costList = { 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200 };

    void Start()
    {
        questId = 0;
        questList = new Dictionary<int, QuestData>();
        int questCount = Random.Range(5, 8);
        for (int i = 0; i < questCount; i++) {
            QuestAdd();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void QuestAdd() {
        int potid = Random.Range(1, 11);
        int count = Random.Range(1, 11);
        int cost = costList[potid] * count;
        questId++;
        questList.Add(questId, new QuestData(potid, count, cost));
        Debug.Log(questList);
    }
}
