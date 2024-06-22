using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientInteraction : MonoBehaviour
{
    public IngredientPickUp item;
    public Inventory inventory;
    public string itemName = "";

    bool isGetItem = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isGetItem)
            {
                GetItem();
            }
        }
    }

    public void GetItem()
    {
        itemName = item.potionIngredient.ingredientName;

        inventory.AddItem(item);
        item.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PotionIngredient"))
        {
            isGetItem = true;

            item = collision.gameObject.GetComponent<IngredientPickUp>();
        }
        else
        {
            isGetItem = false;
        }
    }
}
