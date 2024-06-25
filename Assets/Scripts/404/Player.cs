using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0f;

    Animator anim;
    Canvas canv;

    [SerializeField]
    float playerHealth = 3.0f;

    [SerializeField]
    Image[] hpImage;

    [SerializeField]
    bool isMujuck = false;

    public Transform pivot;
    public int gold = 0;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (playerHealth == 3.0f)
        {
            hpImage[2].enabled = true;
            hpImage[1].enabled = true;
            hpImage[0].enabled = true;
        }
        if (playerHealth == 2.0f)
        {
            hpImage[2].enabled = false;
            hpImage[1].enabled = true;
            hpImage[0].enabled = true;
        }
        if (playerHealth == 1.0f)
        {

            hpImage[2].enabled = false;
            hpImage[1].enabled = false;
            hpImage[0].enabled = true;
        }
        if (playerHealth == 0.0f)
        {
            hpImage[2].enabled = false;
            hpImage[1].enabled = false;
            hpImage[0].enabled = false;
            Debug.Log("You Are Dead");
            return;
        }
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

    IEnumerator MujuckTime()
    {
        int countTime = 0;

        while (countTime < 2)
        {
            yield return new WaitForSeconds(1.0f);
            countTime += 1;
        }

        isMujuck = false;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHealth > 0.0f && collision.gameObject.CompareTag("Enemy") && !isMujuck)
        {
            playerHealth -= 1;
            isMujuck = true;
            StartCoroutine("MujuckTime");
        }
    }
}
