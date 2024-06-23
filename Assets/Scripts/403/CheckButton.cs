using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public int Questnum;
    Dictionary<int, QuestData> questlist;
    GameObject tst;

    public Inventory inv;
    public Player player;

    int potid;
    int count;
    int reward;

    // Start is called before the first frame update
    void Start()
    {
        tst = GameObject.Find("npc");
    }

    private void OnEnable() {
        QuestRefresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void QuestRefresh()
    {
        //여기에 퀘스트 정보 받아오는 코드 입력
        questlist = tst.GetComponent<QuestManager>().questList;

        // 변수는 이 함수 내에서만 계속 값 바꿔가면서 쓸 게 아니면 밖에다가 선언해놓고 쓰기
        potid = questlist[Questnum].PotionId;
        count = questlist[Questnum].Count;
        reward = questlist[Questnum].Cost;
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
            tst.GetComponent<QuestManager>().questList.Remove(Questnum);
        }
    }
}
