using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverFight : MonoBehaviour
{
    [SerializeField]
    VCamController vcamController;
    Animator anim;

    Vida health;

    bool diying = false;
    [SerializeField]
    int damage = 10;

    void Awake()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Vida>();
    }

    void Start()
    {
        GameManager.instance.LoadGamplayStuffs();
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
