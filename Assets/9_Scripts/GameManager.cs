using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    InventorySystem inventorySystem;
    [SerializeField]
    GFInit gf;
    [SerializeField]
    Vida health;
    GameData gameData;

    void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    //en que nivel estoy??
    void OnLevelWasLoaded(int level) 
    {
        if (InGameplay(level))
        {
            inventorySystem = GameObject.FindWithTag("inventory").GetComponent<InventorySystem>();
            health = GameObject.FindWithTag("Player").GetComponent<Vida>();
        }
        
    }

    bool InGameplay(int level) => level > 13 && level < 5;

    public GFInit GetGameFoundation => gf;
    public InventorySystem GetInventorySystem => inventorySystem;
    public Vida GetHealth => health;
    public GameData CurrentGameData{get => gameData; set => gameData = value;}
}
