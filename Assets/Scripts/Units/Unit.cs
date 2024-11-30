using System;
using System.Collections.Generic;
using UnityEngine;

internal abstract class Unit : MonoBehaviour
{
    //public abstract string Sprite { get; }
    public int MaxHealthPoints;
    private Animation Glow;
    internal int healthPoints;
    internal int shield = 0;
    public Die Die;
    internal List<Status> statuses = new();
    internal bool isStunned = false;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    internal virtual void Awake()
    {
        Glow = GetComponent<Animation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        healthPoints = MaxHealthPoints;
    }

    internal virtual void RollDie()
    {
        Die.Roll();
    }

    internal virtual void ResolveDie()
    {
        Die.Resolve();
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
        CombatData.UnitDied(this);

        //Die Anim
        //Disable object?
    }

    internal void TurnGlowOn()
    {
        Glow.Play();
    }

    internal void TurnGlowOff()
    {
        Glow.Stop();
        Glow.Rewind();

        ResetColor();
    }

    internal void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }

    internal void ResetColor()
    {
        spriteRenderer.color = originalColor;
    }
}
