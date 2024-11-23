using System;
using System.Collections.Generic;

internal abstract class Unit
{
    public int maxHealthPoints;
    public int healthPoints;
    public int shield = 0;
    public Dice dice;
    internal List<Status> statuses;

    public Quickness quickness;
    internal bool isStunned = false;

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
        this.healthPoints = Math.Max(healthPoints+healing, maxHealthPoints);
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
