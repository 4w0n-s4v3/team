using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text dialogText;
    // Start is called before the first frame update
    void Start()
    {
        dialogText.text = "";
        string sampleText = "The Quick Brown Fox Jumps Over The Lazy Dog.";
        StartCoroutine(Typing(sampleText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Typing(string text) {
        foreach (char letter in text.ToCharArray()) {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
