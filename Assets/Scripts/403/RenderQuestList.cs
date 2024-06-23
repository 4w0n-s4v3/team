using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderQuestList : MonoBehaviour
{
    // Start is called before the first frame update
    public int Questnum;
    Dictionary<int, QuestData> questlist;
    GameObject tst;
    void Start()
    {
        tst = GameObject.Find("npc");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuest();
    }

    void UpdateQuest() {
        GameObject text = transform.GetChild(4).gameObject;
        GameObject image = transform.GetChild(3).gameObject;
        questlist = tst.GetComponent<QuestManager>().questList;
        Sprite[] imgData = tst.GetComponent<QuestManager>().images;
        //Debug.Log(questlist);
        //Debug.Log(questlist[Questnum]);
        //Debug.Log(questlist[Questnum].Count);
        //Debug.Log(text);
        if (questlist.ContainsKey(Questnum)) {
            text.GetComponent<Text>().text = "x" + questlist[Questnum].Count;
            image.GetComponent<Image>().sprite = imgData[Questnum];
        }
    }
}
