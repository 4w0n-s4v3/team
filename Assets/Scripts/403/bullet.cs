using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 1000f;
    public GameObject mainCamera;
    private float lifetime = 5f;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (Time.time - spawnTime > lifetime) {
            //Destroy(gameObject);
        }
    }
    
}
