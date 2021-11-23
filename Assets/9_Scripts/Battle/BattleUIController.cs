using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIController : MonoBehaviour
{
    [SerializeField]
    Button btnAttack;
    [SerializeField]
    Button btnDefend;
    [SerializeField]
    Button btnGiveUp;
    [SerializeField]
    Button btnRun;

    // Start is called before the first frame update
    void Start()
    {
        btnAttack.onClick.AddListener(Attack);
        btnDefend.onClick.AddListener(Defense);
        btnGiveUp.onClick.AddListener(GiveUp);
        btnRun.onClick.AddListener(Run);
    }

    public void Attack()
    {
        if(BattleManager.instance.IsPlayerTurn) BattleManager.instance.GetRiverFight.Attack();
    }

    public void Defense()
    {
        if(BattleManager.instance.IsPlayerTurn) BattleManager.instance.GetRiverFight.Defense();
        BattleManager.instance.ChangeTurn();
    }

     public void GiveUp()
    {
        if(BattleManager.instance.IsPlayerTurn) BattleManager.instance.GetRiverFight.GiveUp();
    }
     public void Run()
    {
        if(BattleManager.instance.IsPlayerTurn) BattleManager.instance.GetRiverFight.Run();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
