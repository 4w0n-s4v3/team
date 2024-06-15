using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float HP;
    // Start is called before the first frame update
    private GameObject par;
    void Start()
    {
        par = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("bullet")) {
            Debug.Log("adfs");
            HP -= 5;
            if (HP <= 0) Destroy(par);
            Destroy(collision.gameObject);
        }
    }
}
