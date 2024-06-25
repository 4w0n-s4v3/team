using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public RectTransform inventory;
    public RectTransform questlist;
    
    public Text goldText;

    bool isMove = true;
    public bool isInv = false;
    public bool isQue = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isUII)
        {
            if (Input.GetKeyDown(KeyCode.I) && isMove)
            {
                StartCoroutine(MoveFromTo());
            }
            if (Input.GetKeyDown(KeyCode.Q) && isMove)
            {
                StartCoroutine(MoveFromTo2());
            }
    
            goldText.text = GameManager.instance.player.gold.ToString();
        }
    }

    void InvEnable()
    {
    }

    IEnumerator MoveFromTo()
    {
        if (!isInv)
        {
            inventory.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
        else Time.timeScale = 1;

        isMove = false;

        float t = 0f;
        Vector3 movePosition;
    
        if (!isInv) movePosition = new Vector3(inventory.localPosition.x, 170.0f);
        else movePosition = new Vector3(inventory.localPosition.x, -700.0f);

        while (t < 1f)
        {
            t += 1f * Time.unscaledDeltaTime;
            inventory.localPosition = Vector3.Lerp(inventory.localPosition, movePosition, t);
            yield return null;
        }
        if (isInv) inventory.gameObject.SetActive(false);

        isInv = !isInv;
        isMove = true;
    }

    IEnumerator MoveFromTo2()
    {
        if (!isQue)
        {
            questlist.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
        else Time.timeScale = 1;

        isMove = false;

        float t = 0f;
        Vector3 movePosition;
    
        if (!isQue) movePosition = new Vector3(questlist.localPosition.x, 0.0f);
        else movePosition = new Vector3(questlist.localPosition.x, -1100.0f);

        while (t < 1f)
        {
            t += 1f * Time.unscaledDeltaTime;
            questlist.localPosition = Vector3.Lerp(questlist.localPosition, movePosition, t);
            yield return null;
        }
        if (isQue) questlist.gameObject.SetActive(false);

        isQue = !isQue;
        isMove = true;
    }
}
