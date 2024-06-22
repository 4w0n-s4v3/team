using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public enum Set { Select, Deselect, Buy }

    [Header("# UI Controller")]
    public UIControl uiControl;

    [Header("# Base Parameter")]
    public GameObject selectSlot;
    public List<IngredientPickUp> items;

    public GameObject itemNameBox;
    public Text itemName;

    public int slotLength;

    public ScrollRect scrollRect;
    public Transform upScroll;
    public Transform downScroll;

    [Header("# Slots")]
    public Transform slotParent;

    public Slot[] slots;
    public int currentSlot = 0;

#if UNITY_EDITOR
    public void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    virtual public void Awake()
    {
        FreshSlot();
        SelectItem();
    }

    virtual public void OnEnable()
    {
        Debug.Log("Enable");
        scrollRect.verticalScrollbar.value = 1.0f;
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
        if (slots[currentSlot].transform.position.y > upScroll.position.y)
            scrollRect.verticalScrollbar.value += 0.5f;
        else if (slots[currentSlot].transform.position.y < downScroll.position.y)
            scrollRect.verticalScrollbar.value -= 0.5f;

        selectSlot.transform.position = slots[currentSlot].transform.position;

        if (slots[currentSlot].item)
        {
            itemNameBox.SetActive(true);
            TextPrint();
        }
        else itemNameBox.SetActive(false);
    }

    virtual public void TextPrint()
    {
        IngredientPickUp slotItem = slots[currentSlot].item;

        itemName.text = slotItem.potionIngredient.ingredientName;
    }

    virtual public void FreshSlot()
    {
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

    public void AddItem(IngredientPickUp _item)
    {
        Debug.Log("Add");
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