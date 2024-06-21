using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public int PotionId;
    public int Count;
    public int Cost;

    public QuestData(int potion, int count, int cost)
    {
        PotionId = potion;
        Count = count;
        Cost = cost;
    }
}
