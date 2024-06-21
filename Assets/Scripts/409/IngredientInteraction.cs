using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IngredientInteraction : MonoBehaviour
{
    public IngredientPickUp item;
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
        item.count += 1;
        itemName = item.potionIngredient.ingredientName;
        Debug.Log(itemName + " " + item.count);

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
            item = null;
            isGetItem = false;
        }
    }
}
