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

    public GFInit GetGameFoundation => gf;
    public InventorySystem GetInventorySystem => inventorySystem;
    public Vida GetHealth => health;
    public GameData CurrentGameData{get => gameData; set => gameData = value;}
}
