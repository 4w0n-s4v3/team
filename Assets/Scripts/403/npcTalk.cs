using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcTalk : MonoBehaviour
{
    public DialogController dialog;
    // GameObject target;

    List<string> data;
    bool isTalk = false;
    int talkIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // NPC 상호작용 범위 이내에 있음 && 타이핑 중이 아님 && 엔터 누름
        if (isTalk && !dialog.isTyping && Input.GetKeyDown(KeyCode.Return))
        {
            PrintTalk();
        }
    }

    // void OnTriggerEnter2D(Collider other) {
    //     Debug.Log("asdf");
    //     if (other.gameObject.CompareTag("Player")) {
    //         GameObject panel = GameObject.FindWithTag("npcText");
    //         if (panel == null) return;
    //         panel.SetActive(true);
    //     }
    // }

    void PrintTalk()
    {
        // 채팅창 꺼져 있을 때 (gameObject 활성화 상태 확인: activeSelf(bool))
        if (!dialog.gameObject.activeSelf)
        {
            dialog.gameObject.SetActive(true);

            data = transform.GetComponent<QuestManager>().talkData;
            for (int i = 0; i < data.Count; i++) {
                Debug.Log(data[i]);
            }
        }

        // index 형식으로 엔터 한 번 칠 때마다 +1
        // 끝까지 다 출력한 상태에서 엔터 누르면 대화창 종료
        if (talkIndex == data.Count)
        {
            talkIndex = 0;
            dialog.gameObject.SetActive(false);

            return;
        }

        dialog.StartCoroutine(dialog.Typing(data[talkIndex]));

        talkIndex++;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player")) {
            isTalk = true;
        }
        else isTalk = false;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) isTalk = false;
    }
}
