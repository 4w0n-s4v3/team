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

        RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), playerDir, 1.0f);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), playerDir * 1.0f, Color.red);
        for (int i = 1; i < hit.Length; i++)
        {
            Debug.Log(hit[i].collider.name);

            if (hit[i].collider.CompareTag("PotionIngredient"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Input E");
                    itemCount += 1;
                    itemName = hit[i].collider.name;
                    Debug.Log(itemName + " " + itemCount);
                    Destroy(hit[i].collider.gameObject);
                }
                break;
            }
        }
    }
}