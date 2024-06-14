using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion Ingredient", menuName = "New Potion Ingredient/potion ingredient")]
public class PotionIngredient : ScriptableObject  // 게임 오브젝트에 붙일 필요 X 
{
    public enum IngredientTag  // 재료 속성
    {
        None,
    }

    public string ingredientName; // 재료 이름
    public IngredientTag ingredientTag; // 재료 속성
    public Sprite ingredientImage; // 재료 이미지(인벤 토리 안에서 띄울)
    public GameObject ingredientPrefab;  // 재료 프리팹 (아이템 생성시 프리팹으로 찍어냄)
    public string ingredientDescription; // 재료 설명
    public string ingredientFlavor; // 재료 플레이버 텍스트
}
