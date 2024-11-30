using UnityEngine;

internal class TargetEnemy : TargetSelectionStrategy
{
    private Enemy enemy = null;

    public TargetEnemy(CombatSystem context) : base(context) { }
    internal override bool ReadyToConfirm => enemy;
    internal override void Update() 
    { 
        HandleTargetSelection();
    }

    private void HandleTargetSelection()
    {
        Enemy clickedEnemy = Selector.GetUnitOnClick<Enemy>(context.enemiesLayer);
        
        if (!clickedEnemy)
            return;

        enemy = clickedEnemy;
        enemy.ChangeColor(Color.red);
    }

    internal override void SetTarget(Face face) 
    { 
        face.SetEnemyTarget(enemy);
        ResetTarget();
    }

    private void ResetTarget() 
    { 
        enemy.ResetColor();
        enemy = null;
    }
}