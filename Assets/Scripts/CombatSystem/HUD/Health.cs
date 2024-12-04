using System;
using TMPro;
using UnityEngine;

internal class Health: MonoBehaviour
{
    private Unit unit;
    private int max;
    private int current;
    private TextMeshPro text;

    internal void Awake()
    {
        text = GetComponentInChildren<TextMeshPro>();
    }

    internal void Attach(Unit unit)
    {
        this.unit = unit;
        max = unit.MaxHealth;
        current = max;

        SetTextProperties();
    }

    internal void Heal(int amount)
    {
        current = Math.Min(current + amount, max);

        SetTextProperties();
    }

    internal void Damage(int amount)
    {
        current = Math.Max(current - amount, 0);

        SetTextProperties();

        if(current == 0)
            unit.ToDie();
    }

    private void SetTextProperties()
    {
        text.text = current.ToString();
        text.color = current == max ? Color.white: Color.red;
        
        text.outlineColor = Color.black;
        text.outlineWidth = 0.3f; 
    }
}