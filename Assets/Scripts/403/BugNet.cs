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
            Rotation();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        transform.position = new Vector3(playerPos.position.x + 0.21f, playerPos.position.y + 0.22f, playerPos.position.z);
    }

    private void Rotation(){
        float spd = 1.0f;
        Quaternion from = Quaternion.Euler(new Vector3(0, 0, 0));
        Quaternion to = Quaternion.Euler(new Vector3(0, 0, 140));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, to, spd * Time.deltaTime);
    }
}
