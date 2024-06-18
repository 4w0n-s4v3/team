using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInteraction : MonoBehaviour
{
    public int itemCount = 0;
    public string itemName = "";

    void Update()
    {

        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 50f);
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.red);
        if (hit)
        {
            if (hit.collider.CompareTag("PotionIngredient"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Input E");
                    itemCount += 1;
                    itemName = hit.collider.name;
                    Debug.Log(itemName + " " + itemCount);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}