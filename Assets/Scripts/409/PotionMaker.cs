using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PotionMaker : MonoBehaviour
{
    public PotionMakerInventory makerInv;

    public PotionPickUp[] potions;

    public int potionId;
    public Potion potion;

    public Button button;

    bool isMake;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
    }

    public void PotionCheck()
    {
        makerInv.potionSlot.potion = null;

        foreach (Slot slot in makerInv.selectSlots)
            if (slot.ingredient == null) return;

        var p0 = makerInv.selectSlots[0].ingredient.potionIngredient.ingredientName;
        var p1 = makerInv.selectSlots[1].ingredient.potionIngredient.ingredientName;
        var p2 = makerInv.selectSlots[2].ingredient.potionIngredient.ingredientName;

        int resultPotionId = 0;

        if (p0 == "들판 고사리" && p1 == "에메랄드 뿌리" && p2 == "여린꽃")
            resultPotionId = 1;
        if (p0 == "들판 고사리" && p1 == "신비의 푸른 잎" && p2 == "에메랄드 뿌리")
            resultPotionId = 2;
        if (p0 == "들판 고사리" && p1 == "소나무 솔바늘" && p2 == "은은한 향기 꽃")
            resultPotionId = 3;
        if (p0 == "그림자꽃" && p1 == "푸른나무 견과류" && p2 == "잿빛나무 열매")
            resultPotionId = 4;
        if (p0 == "그림자꽃" && p1 == "잿빛나무 열매" && p2 == "에메랄드 뿌리")
            resultPotionId = 5;
        if (p0 == "숲속불꽃" && p1 == "에메랄드 뿌리" && p2 == "신비의 푸른 잎")
            resultPotionId = 6;
        if (p0 == "동굴이끼" && p1 == "숲속 불꽃" && p2 == "동굴 고홍")
            resultPotionId = 7;
        if (p0 == "동굴이끼" && p1 == "지하수리" && p2 == "동굴푸른꽃")
            resultPotionId = 8;
        if (p0 == "동굴고홍" && p1 == "숲속 불꽃" && p2 == "어둠의 근본")
            resultPotionId = 9;
        if (p0 == "동굴고홍" && p1 == "동굴가시" && p2 == "신비의 푸른 잎")
            resultPotionId = 10;
        if (p0 == "반짝이는 석류" && p1 == "어둠의 근본" && p2 == "지하 열매")
            resultPotionId = 11;
        if (p0 == "반짝이는 석류" && p1 == "에메랄드 뿌리" && p2 == "지하 열매")
            resultPotionId = 12;
        if (p0 == "감자" && p1 == "감자" && p2 == "감자")
            resultPotionId = 13;

        potionId = resultPotionId;

        Debug.Log(potionId);

        if (potionId != 0)
        {
            isMake = true;
            makerInv.potionSlot.potion = potions[potionId - 1];
        }
        else
            isMake = false;
    }

    public void PotionMake()
    {
        if (!isMake) return;

        GameManager.instance.inventory.AddItem(potions[potionId - 1]);

        for (int i = 0; i < makerInv.selectSlots.Length; i++)
        {
            makerInv.counts[i]--;

            if (makerInv.counts[i] == 0) makerInv.selectSlots[i].ingredient = null;
        }

        makerInv.FreshSlot();
        makerInv.potionSlot.potion = null;
        isMake = false;
        
        PotionCheck();
    }
}