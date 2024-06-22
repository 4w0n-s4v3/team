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

    IngredientPickUp _ingredient;
    PotionPickUp _potion;

    public IngredientPickUp ingredient
    {
        get { return _ingredient; }
        set
        {
            _ingredient = value;
            if (_ingredient != null)
            {
                potion = null;
                EnableItem(false);
            }
            else
            {
                DisableItem();
            }
        }
    }

    public PotionPickUp potion
    {
        get { return _potion; }
        set
        {
            _potion = value;
            if (_potion != null)
            {
                ingredient = null;
                EnableItem(true);
            }
            else
            {
                DisableItem();
            }
        }
    }

    virtual public void EnableItem(bool isPotion)
    {
        if (isPotion)
        {
            itemImage.sprite = _potion.potion.potionImage;
            countText.text = _potion.count.ToString();
        }
        else
        {
            itemImage.sprite = _ingredient.potionIngredient.ingredientImage;
            countText.text = _ingredient.count.ToString();
        }

        itemImage.color = new Color(1, 1, 1, 1);
    }

    virtual public void DisableItem()
    {
        itemImage.color = new Color(1, 1, 1, 0);
    }
}
