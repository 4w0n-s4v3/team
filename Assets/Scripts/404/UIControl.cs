using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public RectTransform inventory;

    bool isMove = true;
    public bool isInv = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && isMove)
        {
            StartCoroutine(MoveFromTo());
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
}
