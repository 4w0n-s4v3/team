using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PotionMaker : MonoBehaviour
{
    public Inventory inventory;

    [SerializeField]
    private List<PotionIngredient> pingList;
    [SerializeField]
    private bool buttonPress = false;

    public Potion[] potionList;

    public string potionName = "";
    public Potion potion;

    public Button button;


    void Start()
    {
        button.onClick.AddListener(() =>
        {
            PotionCheck(pingList);
            buttonPress = true;
        });
    }

    void FixedUpdate()
    {
        if (buttonPress)
        {
            for (int i = 0; i < potionList.Length; i++)
            {
                if (potionList[i].potionName == potionName)
                {
                    potion = potionList[i];
                    buttonPress = false;
                    break;
                }
            }
        }
    }

    void PotionCheck(List<PotionIngredient> pingList)
    {
        var p0 = pingList[0].ingredientName;
        var p1 = pingList[1].ingredientName;
        var p2 = pingList[2].ingredientName;

        var resultPotionName = "";

        if (pingList.Count > 0)
        {
            if (p0 == "들판 고사리" && p1 == "에메랄드 뿌리" && p2 == "여린꽃")
                resultPotionName = "체력 포션";
            if (p0 == "들판 고사리" && p1 == "신비의 푸른 잎" && p2 == "에메랄드 뿌리")
                resultPotionName = "스테미나 포션";
            if (p0 == "들판 고사리" && p1 == "소나무 솔바늘" && p2 == "은은한 향기 꽃")
                resultPotionName = "신속 포션";
            if (p0 == "그림자꽃" && p1 == "푸른나무 견과류" && p2 == "잿빛나무 열매")
                resultPotionName = "구속 포션";
            if (p0 == "그림자꽃" && p1 == "잿빛나무 열매" && p2 == "에메랄드 뿌리")
                resultPotionName = "독 포션";
            if (p0 == "숲속불꽃" && p1 == "에메랄드 뿌리" && p2 == "신비의 푸른 잎")
                resultPotionName = "힘 포션";
            if (p0 == "동굴이끼" && p1 == "숲속 불꽃" && p2 == "동굴 고홍")
                resultPotionName = "화염 포션";
            if (p0 == "동굴이끼" && p1 == "지하수리" && p2 == "동굴푸른꽃")
                resultPotionName = "냉기 포션";
            if (p0 == "동굴고홍" && p1 == "숲속 불꽃" && p2 == "어둠의 근본")
                resultPotionName = "폭발 포션";
            if (p0 == "동굴고홍" && p1 == "동굴가시" && p2 == "신비의 푸른 잎")
                resultPotionName = "번개 포션";
            if (p0 == "반짝이는 석류" && p1 == "어둠의 근본" && p2 == "지하 열매")
                resultPotionName = "발광 포션";
            if (p0 == "반짝이는 석류" && p1 == "에메랄드 뿌리" && p2 == "지하 열매")
                resultPotionName = "재생 포션";
            if (p0 == "감자" && p1 == "감자" && p2 == "감자")
                resultPotionName = "보드카";
        }

        potionName = resultPotionName;
    }
}