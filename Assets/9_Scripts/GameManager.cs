using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    InventoryUIController inventoryUIController;
    InventorySystem inventorySystem;
    [SerializeField]
    GFInit gf;
    [SerializeField]
    Vida health;
    GameData gameData = new GameData();
    [SerializeField]
    HealthBar healthBar;
    RiverFight riverFight;
    string lastSceneName;

    void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            gf.Init();
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
            LoadGamplayStuffs();
        }
    }

    public void LoadGamplayStuffs()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        health = GameObject.FindWithTag("Player").GetComponent<Vida>();

        if(SceneManager.GetActiveScene().name == "Battle")
        {
            //inventoryUIController = GameObject.FindWithTag("inventory").GetComponent<InventoryUIController>();
            //inventorySystem = inventoryUIController.GetInventorySystem;
            healthBar = GameObject.FindWithTag("health").GetComponent<HealthBar>();
            riverFight = GameObject.FindWithTag("Player").GetComponent<RiverFight>();

        }
        else
        {
            inventoryUIController = GameObject.FindWithTag("inventory").GetComponent<InventoryUIController>();
            inventorySystem = inventoryUIController.GetInventorySystem;
            healthBar = inventoryUIController.GetHealthBar;
        }
        healthBar.SetMaxHealth(health.MaxHealth);
    }

    bool InGameplay(int level) => level > 0 && level < 3;

    public GFInit GetGameFoundation => gf;
    public InventorySystem GetInventorySystem => inventorySystem;
    public Vida GetHealth => health;
    public GameData CurrentGameData{get => gameData; set => gameData = value;}
    public HealthBar GetHealthBar => healthBar;
    public RiverFight GetRiverFight => riverFight;
    public string LastSceneName{get => lastSceneName; set => lastSceneName = value;}
    public void UpdateItemsInCurrentData() => CurrentGameData.Items = GetGameFoundation.ItemDefinitionKeys.ToArray();
    public void UpdateHealthInCurrentData() => CurrentGameData.CurrentPlayerHealth = GetHealth.CurrentHealth;
}
