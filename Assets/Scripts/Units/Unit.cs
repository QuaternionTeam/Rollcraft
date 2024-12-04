using System;
using System.Collections.Generic;
using UnityEngine;

internal abstract class Unit : MonoBehaviour
{
    //public abstract string Sprite { get; }
    public int MaxHealth;
    private Animation Glow;

    [SerializeField] protected Die DiePrefab;
    protected Die DieInstance;
    internal Die Die => DieInstance;

    [SerializeField] protected Health HealthPrefab;
    protected Health HealthInstance;

    internal List<Status> statuses = new();
    internal bool isStunned = false;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    internal virtual void Awake()
    {
        Glow = GetComponent<Animation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    internal virtual void RollDie()
    {
        DieInstance.Roll();
    }

    internal virtual void ResolveDie()
    {
        DieInstance.Resolve();
    }

    internal void StartTurn()
    {
        //shield = 0;
    }
    
/*
    internal void RecieveAttack(int damage)
    {
        int damageAfterShield = CalculateDamageAfterShield(damage);

        if (damageAfterShield == 0)
            return;

        Damage(damageAfterShield);

        foreach(Status status in statuses)
            status.OnRecieveAttack(this, damageAfterShield);
    }
*/
/*
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
*/

    internal void Heal(int amount)
    {
        //TODO: Await Healing Anim
        HealthInstance.Heal(amount);
    }

    internal void Damage(int amount)
    {
        //TODO: Await Dagame Anim
        HealthInstance.Damage(amount);
    }

    internal void Shield(int shield)
    {
        //this.shield += shield;
        //TODO: Await Shield Anim
    }

    internal void ApplyStatus(Status status)
    {
        statuses.Add(status);
    }

    internal void ToDie()
    {
        CombatData.UnitDied(this);
        gameObject.SetActive(false);
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
