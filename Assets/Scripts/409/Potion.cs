using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "New Potion/potion")]
public class Potion : ScriptableObject  // 게임 오브젝트에 붙일 필요 X 
{
    public string potionName; // 재료 이름
    public Sprite potionImage; // 재료 이미지(인벤 토리 안에서 띄울)
    public GameObject potionPrefab;  // 재료 프리팹 (아이템 생성시 프리팹으로 찍어냄)
    public string potionDescription; // 재료 설명
    public string potionFlavor; // 재료 플레이버 텍스트
}