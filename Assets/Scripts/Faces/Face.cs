using System;
using UnityEngine;

internal abstract class Face: MonoBehaviour
{
    //internal int diceIndex;
    //[SerializeField] private Sprite Sprite;

    protected Die die;
    internal abstract SelectionStrategy Target { get; }

    internal void SetDie(Die die)
    {
        this.die = die;
    }

    internal abstract void OnLand();

    internal abstract void Resolve();
}
