using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("# UI Controller")]
    public UIControl uiControl;

    [Header("# Base Parameter")]
    public GameObject selectSlot;
    public List<IngredientPickUp> ingredientItems;
    public List<PotionPickUp> potionItems;

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
    }

    virtual public void OnEnable()
    {
        Debug.Log("Enable");
        scrollRect.verticalScrollbar.value = 1.0f;
        selectSlot.transform.position = slots[currentSlot].transform.position;
        currentSlot = 0;
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

        SelectItem();
    }

    virtual public void SelectItem()
    {
        selectSlot.transform.position = slots[currentSlot].transform.position;

        if (slots[currentSlot].transform.position.y > upScroll.position.y)
            scrollRect.verticalScrollbar.value += 0.5f;
        else if (slots[currentSlot].transform.position.y < downScroll.position.y)
            scrollRect.verticalScrollbar.value -= 0.5f;

        if (slots[currentSlot].potion || slots[currentSlot].ingredient)
        {
            itemNameBox.SetActive(true);
            TextPrint();
        }
        else itemNameBox.SetActive(false);
    }

    virtual public void TextPrint()
    {
        if (!slots[currentSlot].potion)
        {
            IngredientPickUp slotItem = slots[currentSlot].ingredient;

            itemName.text = slotItem.potionIngredient.ingredientName;
        }
        else
        {
            PotionPickUp slotItem = slots[currentSlot].potion;

            itemName.text = slotItem.potion.potionName;
        }
    }

    virtual public void FreshSlot()
    {
       // items = items.OrderByDescending(x => x.id / 10).ThenBy(x => x.id % 10).ThenByDescending(x => x.level).ToList();

       for (int k = potionItems.Count - 1; k >= 0; k--)
        {
            if (potionItems[k].count <= 0)
            {
                potionItems[k].count = 0;
                potionItems.RemoveAt(k);
            }
        }
        for (int k = ingredientItems.Count - 1; k >= 0; k--)
        {
            if (ingredientItems[k].count <= 0)
            {
                ingredientItems[k].count = 0;
                ingredientItems.RemoveAt(k);
            }
        }

        int i = 0;
        for (; i < potionItems.Count && i < slots.Length; i++)
        {
            slots[i].potion = potionItems[i];
        }
        for (; i < ingredientItems.Count && i < slots.Length; i++)
        {
            slots[i].ingredient = ingredientItems[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].potion = null;
            slots[i].ingredient = null;
        }
    }

    public void AddItem(IngredientPickUp _item)
    {
        Debug.Log("Add");

        if (ingredientItems.FirstOrDefault(x => x.potionIngredient == _item.potionIngredient) != null)
        {
            ingredientItems.FirstOrDefault(x => x.potionIngredient == _item.potionIngredient).count++;

            return;
        }

        if (ingredientItems.Count < slots.Length)
        {
            ingredientItems.Add(_item);
            _item.count++;
            FreshSlot();
        }
        else
        {
            Debug.Log("슬롯이 가득 차 있습니다.");
        }
    }

    public void AddItem(PotionPickUp _item)
    {
        Debug.Log("Add");

        if (potionItems.FirstOrDefault(x => x.potion == _item.potion) != null)
        {
            potionItems.FirstOrDefault(x => x.potion == _item.potion).count++;

            return;
        }

        if (potionItems.Count < slots.Length)
        {
            potionItems.Add(_item);
            _item.count++;
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