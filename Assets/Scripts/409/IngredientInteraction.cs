using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IngredientInteraction : MonoBehaviour
{
    public int itemCount = 0;
    public string itemName = "";

    float hInput;
    float vInput;
    bool isHorizontalMove;
    Vector3 playerDir;

    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        if (hInput == 0 && vInput != 0)
        {
            isHorizontalMove = false;
            if (vInput == 1)
                playerDir = Vector3.up;
            else if (vInput == -1)
                playerDir = Vector3.down;
        }
        else
        {
            isHorizontalMove = true;
            if (hInput == 1)
                playerDir = Vector3.right;
            else if (hInput == -1)
                playerDir = Vector3.left;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Debug.Log(this.name);
        if (collision.gameObject.CompareTag("PotionIngredient")) {
                itemCount += 1;
                itemName = collision.name;
                Debug.Log(itemName + " " + itemCount);
                Destroy(collision.gameObject);
        }
    }
}