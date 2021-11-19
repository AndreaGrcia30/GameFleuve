using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverFight : BattleActor
{
    [SerializeField]
    VCamController vcamController;
    Vida health;

    new void Awake()
    {
        base.Awake();
        health = GetComponent<Vida>();
    }

    void Start()
    {
        GameManager.instance.LoadGamplayStuffs();
        //GameManager.instance.LastSceneName = "Battle";
    }

    void Update()
    {
        if(ImDead)
        {
            if(!diying)
            {
                diying = true;
                anim.SetTrigger("Death");
            }
            return;
        }
    }

    void ShakeCamera() => vcamController.Shake();

    public void GetDamage()
    {
        anim.SetTrigger("Hurt");
    }

    void MakeDamage()
    {
        if(ImDead) return;
        BattleManager.instance.GetBattleEnemy.GetDamage(damage);
    }

    public void Attack()
    {
        if(ImDead) return;
        anim.SetTrigger("Attack");
    }

    bool ImDead => health.CurrentHealth == 0;
}
