using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class BugNet : MonoBehaviour
{

    private Transform tr;
    public Transform playerPos;
    public GameObject player;
    Quaternion from = Quaternion.Euler(new Vector3(0, 0, 0));
    Quaternion to = Quaternion.Euler(new Vector3(0, 0, 140));

    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.transform;
        tr.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        if(Input.GetKey(KeyCode.Mouse0)) {
            transform.rotation = to;
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            transform.rotation = from;
        }
        transform.position = new Vector3(playerPos.position.x + 0.21f, playerPos.position.y + 0.22f, playerPos.position.z);
        
        // for (int i = 1; i < hit.Length; i++)
        // {
        //     Debug.Log(hit[i].collider.name);

        //     if (hit[i].collider.CompareTag("PotionIngredient"))
        //     {
                
        //         Debug.Log("Input E");
        //         itemCount += 1;
        //         itemName = hit[i].collider.name;
        //         Debug.Log(itemName + " " + itemCount);
        //         Destroy(hit[i].collider.gameObject);
                
        //         break;
        //     }
        // }


    }
}
