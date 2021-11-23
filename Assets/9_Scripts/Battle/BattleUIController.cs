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

    // Start is called before the first frame update
    void Start()
    {
        btnAttack.onClick.AddListener(Attack);
        btnDefend.onClick.AddListener(Defense);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
