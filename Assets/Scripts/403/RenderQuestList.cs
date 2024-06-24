using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderQuestList : MonoBehaviour
{
    public GameObject clearText;
    // Start is called before the first frame update
    public int Questnum;
    Dictionary<int, QuestData> questlist;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuest();
    }

    void UpdateQuest() {
        GameObject text = transform.GetChild(4).gameObject;
        GameObject image = transform.GetChild(3).gameObject;
        questlist = GameManager.instance.questManager.questList;
        Sprite[] imgData = GameManager.instance.questManager.images;
        //Debug.Log(questlist);
        //Debug.Log(questlist[Questnum]);
        //Debug.Log(questlist[Questnum].Count);
        //Debug.Log(text);
        if (questlist.ContainsKey(Questnum) && !questlist[Questnum].Clear) {
            clearText.SetActive(false);
            text.GetComponent<Text>().text = "x" + questlist[Questnum].Count;
            image.GetComponent<Image>().sprite = imgData[questlist[Questnum].PotionId - 1];
            image.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            text.GetComponent<Text>().text = "";
            image.GetComponent<Image>().sprite = null;
            image.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            clearText.SetActive(true);
        }
    }
}
