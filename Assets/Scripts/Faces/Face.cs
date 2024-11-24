using System.Collections.Generic;
using System.Linq;
using System.Reflection;

internal abstract class Face
{
    internal List<MethodInfo> FastMethods { get; private set; } = new List<MethodInfo>();
    internal List<MethodInfo> SlowMethods { get; private set; } = new List<MethodInfo>();
    internal List<MethodInfo> NeutralMethods { get; private set; } = new List<MethodInfo>();
    internal List<MethodInfo> OnLandMethods { get; private set; } = new List<MethodInfo>();

    protected readonly Unit unit;
    internal Enemy enemyTarget = null;
    internal Adventurer adventurerTarget = null;


    internal List<Enemy> enemies = null;
    internal List<Adventurer> adventurers = null;
    internal abstract TargetsCount EnemiesCount { get; }
    internal abstract TargetsCount AdventurersCount { get; }

    internal Face(Unit unit)
    {
        this.unit = unit;
        AddCustomlyDecoratedMethods();
    }

 
    internal void OnLand() 
    { 
        foreach(MethodInfo method in OnLandMethods)
            method.Invoke(this, null);
    }

    internal void ApplyEffect() 
    { 
        foreach(MethodInfo method in NeutralMethods)
            method.Invoke(this, null);
        
        if(unit.quickness == Quickness.Fast)
            foreach(MethodInfo method in FastMethods)
                method.Invoke(this, null);

        if(unit.quickness == Quickness.Slow)
            foreach(MethodInfo method in SlowMethods)
                method.Invoke(this, null);       
    }

    internal bool HasAllTargetsSelected()
    {
        bool AdventurerSelected = adventurerTarget != null || AdventurersCount != TargetsCount.One;
        bool EnemySelected = enemyTarget != null || EnemiesCount != TargetsCount.One;

        return AdventurerSelected && EnemySelected;
    }

    internal void Attack(Unit unit, int damage)
    {
        unit.RecieveAttack(damage);
    }

    internal void Heal(Unit unit, int heal)
    {
        unit.RecieveHealing(heal);
    }

    internal void Protect(Unit unit, int shield)
    {
        unit.RecieveShield(shield);
    }

    internal void Apply(Unit unit, Status status)
    {
        unit.ApplyStatus(status);
    }

       private void AddCustomlyDecoratedMethods()
    {
        var methods = this.GetType()
                          .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                          .Where(m => m.GetCustomAttribute<FastAttribute>() != null)
                          .ToList();
        FastMethods.AddRange(methods);


        methods = this.GetType()
                          .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                          .Where(m => m.GetCustomAttribute<SlowAttribute>() != null)
                          .ToList();
        SlowMethods.AddRange(methods);


        methods = this.GetType()
                          .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                          .Where(m => m.GetCustomAttribute<NeutralAttribute>() != null)
                          .ToList();
        NeutralMethods.AddRange(methods);

        methods = this.GetType()
                          .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                          .Where(m => m.GetCustomAttribute<OnLandAttribute>() != null)
                          .ToList();
        OnLandMethods.AddRange(methods);
    } 

}