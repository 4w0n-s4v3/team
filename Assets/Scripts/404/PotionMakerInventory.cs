using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PotionMakerInventory : MonoBehaviour
{
    [Header("# UI Controller")]
    public UIControl uiControl;

    [Header("# Base Parameter")]
    public Inventory inv;
    public PotionMaker maker;
    public GameObject selectSlot;
    public List<IngredientPickUp> ingredientItems;

    public GameObject itemNameBox;
    public Text itemName;

    public int slotLength;

    [Header("# Slots")]
    public Transform slotParent;

    public Slot[] slots;
    public Slot[] selectSlots;
    public Text[] selectCountTexts;

    public Slot potionSlot;

    public int currentSlot = 0;

    public int[] counts = { 0, 0, 0 };

#if UNITY_EDITOR
    public void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    virtual public void Awake()
    {
        FreshSlot();
    }

    virtual public void OnEnable()
    {
        Debug.Log("Enable");
        selectSlot.transform.position = slots[currentSlot].transform.position;
        currentSlot = 0;
        ingredientItems = inv.ingredientItems;
        FreshSlot();
    }

    virtual public void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (currentSlot - slotLength >= 0)
            {
                currentSlot -= slotLength;
                SelectItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (currentSlot + slotLength < slots.Length)
            {
                currentSlot += slotLength;
                SelectItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentSlot + 1 < slots.Length)
            {
                currentSlot += 1;
                SelectItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentSlot - 1 >= 0)
            {
                currentSlot -= 1;
                SelectItem();
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < selectSlots.Length; i++)
            {
                if (selectSlots[i].ingredient != null)
                {
                    if (slots[currentSlot].ingredient == null || slots[currentSlot].ingredient == selectSlots[i].ingredient)
                    {
                        counts[i]--;
                        selectSlots[i].ingredient.count++;

                        if (counts[i] == 0) selectSlots[i].ingredient = null;

                        break;
                    }
                }
            }
            FreshSlot();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < selectSlots.Length; i++)
            {
                if (selectSlots[i].ingredient != null)
                {
                    if (slots[currentSlot].ingredient == selectSlots[i].ingredient)
                    {
                        counts[i]++;
                        slots[currentSlot].ingredient.count--;
                        break;
                    }
                }
                else
                {
                    selectSlots[i].ingredient = slots[currentSlot].ingredient;
                    counts[i]++;
                    slots[currentSlot].ingredient.count--;
                    maker.PotionCheck();
                    break;
                }
            }
            FreshSlot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < selectSlots.Length; i++)
            {
                if (selectSlots[i].ingredient != null) selectSlots[i].ingredient.count += counts[i];
                counts[i] = 0;
            }

            transform.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        SelectItem();
    }

    virtual public void SelectItem()
    {
        selectSlot.transform.position = slots[currentSlot].transform.position;
    }

    virtual public void FreshSlot()
    {
       // items = items.OrderByDescending(x => x.id / 10).ThenBy(x => x.id % 10).ThenByDescending(x => x.level).ToList();

       ingredientItems = inv.ingredientItems;

        for (int k = ingredientItems.Count - 1; k >= 0; k--)
        {
            if (ingredientItems[k].count <= 0)
            {
                ingredientItems[k].count = 0;
                ingredientItems.RemoveAt(k);
            }
        }

        int i = 0;
        for (; i < ingredientItems.Count && i < slots.Length; i++)
        {
            slots[i].ingredient = ingredientItems[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].potion = null;
            slots[i].ingredient = null;
        }

        for (int j = 0; j < selectSlots.Length; j++)
        {
            selectCountTexts[j].text = counts[j].ToString();
        }

        Debug.Log("FreshSlot");
    }
}