using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text dialogText;

    // 타이핑 중일 때 다중 입력 안 되게 판별하는 변수
    public bool isTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        // string sampleText = "The Quick Brown Fox Jumps Over The Lazy Dog.";
        // StartCoroutine(Typing(sampleText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Typing(string text) {
        isTyping = true;
        dialogText.text = "";

        for (int i = 0; i < text.ToCharArray().Length; i++) {
            dialogText.text += text.ToCharArray()[i];

            if (i + 1 == text.ToCharArray().Length) isTyping = false;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
