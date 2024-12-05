using System;
using UnityEngine;

internal abstract class Face: MonoBehaviour
{
    //internal int diceIndex;
    protected Die die;
    internal abstract SelectionStrategy Target { get; }
    internal abstract string EffectText { get; }
    internal void SetDie(Die die)
    {
        this.die = die;
    }

    internal abstract void OnLand();

    internal abstract void Resolve();
}
