using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public enum Set { Select, Deselect, Buy }

    [Header("# Base Parameter")]
    public GameObject selectSlot;
    public List<IngredientPickUp> items;

    public Text itemName;
    public Text itemDesc;

    public int slotLength;

    [Header("# Slots")]
    public Transform slotParent;

    [HideInInspector] public Slot[] slots;
    [HideInInspector] public int currentSlot = 0;

    virtual public void Awake()
    {
        FreshSlot();
    }

    virtual public void OnEnable()
    {
        selectSlot.transform.position = slots[currentSlot].transform.position;
        currentSlot = 0;
        FreshSlot();
        SelectItem();
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
    }

    virtual public void SelectItem()
    {
        selectSlot.transform.position = slots[currentSlot].transform.position;

        TextPrint();
    }

    virtual public void TextPrint()
    {
        IngredientPickUp slotItem = slots[currentSlot].item;

        itemName.text = slotItem.potionIngredient.ingredientName;
    }

    virtual public void FreshSlot(List<IngredientPickUp> items = null, Slot[] slots = null)
    {
        if (items == null) items = this.items;
        if (slots == null) slots = this.slots;

       // items = items.OrderByDescending(x => x.id / 10).ThenBy(x => x.id % 10).ThenByDescending(x => x.level).ToList();

        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem(IngredientPickUp _item, List<IngredientPickUp> items = null)
    {
        if (items == null) items = this.items;

        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            Debug.Log("슬롯이 가득 차 있습니다.");
        }
    }

    public Slot[] GetSlots(Slot[] useSlots)
    {
        return useSlots;
    }
}