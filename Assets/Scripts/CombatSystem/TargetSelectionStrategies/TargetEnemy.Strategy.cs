using UnityEngine;

internal class TargetEnemy : TargetSelectionStrategy
{
    private Enemy enemy = null;

    internal TargetEnemy(CombatSystem context) : base(context) { }
    internal override bool ReadyToConfirm => enemy;
    internal override void Update() 
    { 
        HandleTargetSelection();
    }

    private void HandleTargetSelection()
    {
        Enemy clickedEnemy = Selector.GetOnClick<Enemy>(context.enemiesLayer);
        
        if (!clickedEnemy)
            return;

        foreach(Enemy enemy in CombatData.Enemies)
            enemy.TurnGlowOff();

        if(enemy)
            enemy.ResetColor();

        enemy = clickedEnemy;
        enemy.ChangeColor(Color.red);
    }

    internal override void SetTarget(AdventurerFace face) 
    { 
        face.SetEnemyTarget(enemy);
        ResetTarget();
    }

    private void ResetTarget() 
    { 
        enemy.ResetColor();
        enemy = null;
    }

    internal override void Enter()
    {
        foreach(Enemy enemy in CombatData.Enemies)
            enemy.TurnGlowOn();
    }

    internal override void Exit()
    {
        foreach(Enemy enemy in CombatData.Enemies)
            enemy.TurnGlowOff();
    }
}
