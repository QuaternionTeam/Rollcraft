using UnityEngine;

internal abstract class Unit
{
    internal int maxHealthPoints;
    internal int healthPoints;
    internal Dice dice;
    internal List<Status> statuses;

    internal void recieveAttack(int damage)
    {
        recieveDamage(damage);

        statuses.OnRecieveDamage()
    }

    internal void recieveDamage(int damage)
    {
        this.healthPoints = Math.Max(healthPoints-damage,0);
        //TODO: Await Dagame Anim
        if(healthPoints==0)
            Die()
    }

    internal void recieveHealing(int heal)
    {
        this.healthPoints = Math.Max(healthPoints+damage, maxHealthPoints);
        //TODO: Await Healing Anim
    }

    internal void Die()
    {
        //Die Anim
        //Dead true?
    }
}
