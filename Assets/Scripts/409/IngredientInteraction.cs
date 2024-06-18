using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDir, 1.0f);
        Debug.DrawRay(transform.position, playerDir * 1.0f, Color.red);
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