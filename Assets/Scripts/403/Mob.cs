using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mob", menuName = "New Mob/Mob")]
public class Mobs : ScriptableObject  // 게임 오브젝트에 붙일 필요 X 
{
    public enum MobType  // 아이템 유형
    {
        Hostile,
        Neutral,
    }

    public string mobName; // 아이템의 이름
    public MobType mobType; // 아이템 유형
    public GameObject mobPrefab;  // 아이템의 프리팹 (아이템 생성시 프리팹으로 찍어냄)

    public float HP;
}

