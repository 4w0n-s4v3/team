using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderQuest : MonoBehaviour
{
    // Start is called before the first frame update
    public int Questnum;
    Dictionary<int, QuestData> questlist;
    void Start()
    {
        //Debug.Log(tst.GetComponent<QuestManager>().questList);
    }

    void Update()
    {
        //Debug.Log(tst);
        // UpdateQuest();
        //questlist = tst.GetComponent<QuestManager>().questList;
        //Debug.Log(questlist[Questnum].Cost);
        UpdateQuest();
    }

    void UpdateQuest() {
        GameObject text = transform.GetChild(1).gameObject;
        GameObject image = transform.GetChild(0).gameObject;
        questlist = GameManager.instance.questManager.questList;
        Sprite[] imgData = GameManager.instance.questManager.images;
        //Debug.Log(questlist);
        //Debug.Log(questlist[Questnum]);
        //Debug.Log(questlist[Questnum].Count);
        //Debug.Log(text);
        text.GetComponent<Text>().text = "x" + questlist[Questnum].Count;
        image.GetComponent<Image>().sprite = imgData[Questnum];
    }
}
