using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameLib.MemorySystem;

public class BattleEnemy : BattleActor
{
    [SerializeField, Range(1, 100)]
    int health = 30;


    void MakeDamage()
    {
        GameManager.instance.GetHealth.TakeDamage(damage);
        GameManager.instance.GetRiverFight.GetDamage();
        GameManager.instance.UpdateHealthInCurrentData();
    }

    void Update()
    {
        if(ImDead)
        {
            if(!diying)
            {
                diying = true;
                anim.SetTrigger("Dead");
                MemorySystem.SaveGame(GameManager.instance.CurrentGameData, "gamedata");
                SceneManager.LoadScene(GameManager.instance.LastSceneName, LoadSceneMode.Single);
            }
            return;
        }

        //if(BattleManager.instance.IsPlayerTurn) return;

        //logic
    }

    public void Attack() => anim.SetTrigger("Attack");
    public void CheckEnemyTurn()
    {
        ChangeTurn();
        BattleManager.instance.CheckForEnemyTurn();
    }

    public void GetDamage(int damage) => health = health - damage > 0 ? health - damage : 0;
    bool ImDead => health == 0;
}
