using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Object")]
    public Player player;
    public Inventory inventory;
    public QuestManager questManager;

    public bool isUII = false;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable() {
        player = FindObjectOfType<Player>();
        inventory = FindObjectOfType<Inventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
