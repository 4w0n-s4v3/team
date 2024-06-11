using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h == 0 && v == 0) anim.SetBool("Run", false);
        else anim.SetBool("Run", true);

        if (h < 0) transform.localScale = new Vector3(1.5f, transform.localScale.y, transform.localScale.z);
        if (h > 0) transform.localScale = new Vector3(-1.5f, transform.localScale.y, transform.localScale.z);

        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime);
    }
}
