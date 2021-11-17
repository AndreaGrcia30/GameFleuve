using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    InventoryUIController inventoryUIController;
    InventorySystem inventorySystem;
    [SerializeField]
    GFInit gf;
    [SerializeField]
    Vida health;
    GameData gameData;
    [SerializeField]
    HealthBar healthBar;

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
        Debug.Log("hello level");
        if (InGameplay(level))
        {
            inventoryUIController = GameObject.FindWithTag("inventory").GetComponent<InventoryUIController>();
            inventorySystem = inventoryUIController.GetInventorySystem;
            healthBar = inventoryUIController.GetHealthBar;
            health = GameObject.FindWithTag("Player").GetComponent<Vida>();
        }
        
    }

    public void LoadGamplayStuffs()
    {
        inventoryUIController = GameObject.FindWithTag("inventory").GetComponent<InventoryUIController>();
        inventorySystem = inventoryUIController.GetInventorySystem;
        healthBar = inventoryUIController.GetHealthBar;
        health = GameObject.FindWithTag("Player").GetComponent<Vida>();
    }

    bool InGameplay(int level) => level > 0 && level < 3;

    public GFInit GetGameFoundation => gf;
    public InventorySystem GetInventorySystem => inventorySystem;
    public Vida GetHealth => health;
    public GameData CurrentGameData{get => gameData; set => gameData = value;}
    public HealthBar GetHealthBar => healthBar;
}
