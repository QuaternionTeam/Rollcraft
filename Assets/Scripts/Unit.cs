using System;
using System.Collections.Generic;
using UnityEngine;

internal abstract class Unit
{
    internal int maxHealthPoints;
    internal int healthPoints;
    internal Dice dice;
    internal List<Status> statuses;

    internal void RecieveAttack(int damage)
    {
        RecieveDamage(damage);

        foreach(Status status in statuses)
            status.OnRecieveDamage(this, damage);
    }

    internal void RecieveDamage(int damage)
    {
        healthPoints = Math.Max(healthPoints-damage,0);
        //TODO: Await Dagame Anim
        if (healthPoints == 0)
            Die();
    }

    internal void RecieveHealing(int healing)
    {
        this.healthPoints = Math.Max(healthPoints+healing, maxHealthPoints);
        //TODO: Await Healing Anim
    }

    internal void Die()
    {
        //Die Anim
        //Dead true?
    }
}
