using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IngredientInteraction : MonoBehaviour
{
    public int itemCount = 0;
    public string itemName = "";

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PotionIngredient"))
        {
            itemCount += 1;
            itemName = collision.name;
            Debug.Log(itemName + " " + itemCount);
            Destroy(collision.gameObject);
        }
    }
}
