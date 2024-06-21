using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image itemImage;

    public enum SlotType { Armor, Boots, Gloves, Ring, Necklace, Inventory, ArmorShop, Equip, Item }
    public SlotType slotType;

    Item _item;

    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                EnableItem();
            }
            else
            {
                DisableItem();
            }
        }
    }

    virtual public void EnableItem()
    {
        //itemImage.sprite = _item.icon;
        itemImage.color = new Color(1, 1, 1, 1);
    }

    virtual public void DisableItem()
    {
        itemImage.color = new Color(1, 1, 1, 0);
    }
}
