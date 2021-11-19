using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIController : MonoBehaviour
{
    [SerializeField]
    Button btnAttack;

    // Start is called before the first frame update
    void Start()
    {
        btnAttack.onClick.AddListener(Attack);
    }

    public void Attack()
    {
        if(BattleManager.instance.IsPlayerTurn) BattleManager.instance.GetRiverFight.Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
