using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcTalk : MonoBehaviour
{
    GameObject PrintText;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnTriggerEnter2D(Collider other) {
    //     Debug.Log("asdf");
    //     if (other.gameObject.CompareTag("Player")) {
    //         GameObject panel = GameObject.FindWithTag("npcText");
    //         if (panel == null) return;
    //         panel.SetActive(true);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log(GameObject.FindWithTag("Canvas").transform.Find("Talk").gameObject);
            GameObject panel = GameObject.FindWithTag("Canvas").transform.Find("Talk").gameObject;
            if (panel == null) return;
            panel.SetActive(true); //여기까지는 대체로 작동함

            //이게문제임
            List<string> data = this.GetComponent<QuestManager>().talkData;
            for (int i = 0; i < data.Count; i++) {
                Debug.Log(data[i]);
                // panel.transform.Find("Text").gameObject.GetComponent<Text>().text = data[i];
                // if (Input.GetMouseButton(0)) {

                // }
            }
        }
    }
}
