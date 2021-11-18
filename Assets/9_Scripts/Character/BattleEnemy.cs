using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    [SerializeField, Range(1, 100)]
    int damage = 10;
    [SerializeField, Range(1, 100)]
    int health = 30;
    bool diying = false;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void MakeDamage()
    {
        GameManager.instance.GetHealth.TakeDamage(damage);
        GameManager.instance.GetRiverFight.GetDamage();
    }

    void Update()
    {
        if(ImDead)
        {
            if(!diying)
            {
                diying = true;
                anim.SetTrigger("Dead");
            }
            return;
        }
    }

    public void GetDamage(int damage) => health = health - damage > 0 ? health - damage : 0;
    bool ImDead => health == 0;
}
