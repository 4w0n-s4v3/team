using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image itemImage;
    public Text countText;

    // public enum SlotType { Armor, Boots, Gloves, Ring, Necklace, Inventory, ArmorShop, Equip, Item }
    // public SlotType slotType;

    IngredientPickUp _item;

    public IngredientPickUp item
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
        itemImage.sprite = _item.potionIngredient.ingredientImage;
        itemImage.color = new Color(1, 1, 1, 1);
        countText.text = _item.count.ToString();
    }

    virtual public void DisableItem()
    {
        itemImage.color = new Color(1, 1, 1, 0);
    }
}
