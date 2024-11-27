using System;
using System.Collections.Generic;
using UnityEngine;

internal abstract class Unit : MonoBehaviour
{
    //public abstract string Sprite { get; }
    public int MaxHealthPoints;
    internal int healthPoints;
    internal int shield = 0;
    public Die Die;
    internal List<Status> statuses = new();
    internal bool isStunned = false;

    internal virtual void Awake()
    {
        healthPoints = MaxHealthPoints;
    }

    internal void StartTurn()
    {
        shield = 0;
    }
    
    internal void RecieveAttack(int damage)
    {
        int damageAfterShield = CalculateDamageAfterShield(damage);

        if (damageAfterShield == 0)
            return;

        RecieveDamage(damageAfterShield);

        foreach(Status status in statuses)
            status.OnRecieveAttack(this, damageAfterShield);
    }

    private int CalculateDamageAfterShield(int damage)
    {
        int damageAfterShield;

        if(damage > shield)
        {
            shield = 0;
            damageAfterShield = damage - shield;
        }
        else
        {
            damageAfterShield = 0;
            shield -= damage;
        }

        return damageAfterShield;
    }

    internal void RecieveDamage(int damage)
    {
        healthPoints = Math.Max(healthPoints-damage,0);
        //TODO: Await Dagame Anim
        
        if (healthPoints == 0)
        {
            ToDie();
            return;
        }
        
    }

    internal void RecieveShield(int shield)
    {
        this.shield += shield;
        //TODO: Await Shield Anim
    }

    internal void RecieveHealing(int healing)
    {
        healthPoints = Math.Max(healthPoints+healing, MaxHealthPoints);
        //TODO: Await Healing Anim
    }

    internal void ApplyStatus(Status status)
    {
        statuses.Add(status);
    }

    internal void ToDie()
    {
        CombatSystem.Died(this);

        //Die Anim
        //Disable object?
    }
}
