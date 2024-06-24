using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestData
{
    public int PotionId;
    public int Count;
    public int Cost;
    public bool Clear;

    public QuestData(int potion, int count, int cost, bool clear)
    {
        PotionId = potion;
        Count = count;
        Cost = cost;
        Clear = clear;
    }
}
