using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    RenderQuestList quest;
    Dictionary<int, QuestData> questlist;

    Button checkButton;

    public Inventory inv;
    public Player player;

    int potid;
    int count;
    int reward;

    // Start is called before the first frame update
    void Awake()
    {
        checkButton = gameObject.GetComponentInChildren<Button>();
        quest = gameObject.GetComponent<RenderQuestList>();
    }

    private void OnEnable() {
        questlist = GameManager.instance.questManager.questList;

        if (questlist.ContainsKey(quest.Questnum) && !questlist[quest.Questnum].Clear)
        {
            checkButton.gameObject.SetActive(true);
            QuestRefresh();
        }
        else
            checkButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void QuestRefresh()
    {
        //여기에 퀘스트 정보 받아오는 코드 입력
        questlist = GameManager.instance.questManager.questList;

        // 변수는 이 함수 내에서만 계속 값 바꿔가면서 쓸 게 아니면 밖에다가 선언해놓고 쓰기
        potid = questlist[quest.Questnum].PotionId;
        count = questlist[quest.Questnum].Count;
        reward = questlist[quest.Questnum].Cost;
    }

    public void ClickButton()
    {
        //여기에 인벤토리에 필요한 아이템 있는지 확인하는 코드 입력
        //여기에 인벤토리에서 아이템 빼는 코드 입력
        //여기에 돈주는 코드 입력
        //여기에 퀘스트 제거 (혹은 취소선) 하는 코드 입력

        // 조건에 해당하는 첫 번째 값 가져옴
        var questPotion = inv.potionItems.FirstOrDefault(x => x.potion.potionId == potid);

        if (questPotion != null && questPotion.count >= count)
        {
            questPotion.count -= count;
            player.gold += reward;
            GameManager.instance.questManager.questList[quest.Questnum].Clear = true;
            checkButton.gameObject.SetActive(false);
        }
        else Debug.Log("퀘스트 완수에 필요한 아이템이 부족합니다. id: " + potid);
    }
}
