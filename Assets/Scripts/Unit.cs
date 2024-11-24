using System;
using System.Collections.Generic;
using UnityEngine;

internal abstract class Unit : MonoBehaviour
{
    public abstract string Image { get; }
    public abstract int MaxHealthPoints { get; }
    public int healthPoints;
    public int shield = 0;
    public abstract Dice Dice { get; }
    internal List<Status> statuses = new();

    public Quickness quickness;
    internal bool isStunned = false;

    void OnMouseDown()
    {
        CombatSystem.HasBeenClicked(this);
    }

    internal void StartTurn()
    {
        shield = 0;
    }
    
    internal void RecieveAttack(int damage)
    {
        int damageAfterShield = DamageAfterShield(damage);

        if (damageAfterShield == 0)
            return;

        RecieveDamage(damageAfterShield);

        foreach(Status status in statuses)
            status.OnRecieveAttack(this, damageAfterShield);
    }

    private int DamageAfterShield(int damage)
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
            Die();
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
        this.healthPoints = Math.Max(healthPoints+healing, MaxHealthPoints);
        //TODO: Await Healing Anim
    }

    internal void ApplyStatus(Status status)
    {
        this.statuses.Add(status);
    }

    internal void Die()
    {
        //Die Anim
        //Dead true?
    }
}
