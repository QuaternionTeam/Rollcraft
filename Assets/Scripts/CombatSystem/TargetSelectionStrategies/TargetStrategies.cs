internal class TargetStrategies
{
    private readonly NoTarget NoTarget;
    private readonly TargetEnemy TargetEnemy;
    private readonly TargetAdventurer TargetAdventurer;
    private readonly TargetBoth TargetBoth;

    internal TargetStrategies(CombatSystem context) 
    { 
        NoTarget = new(context);
        TargetEnemy = new(context);
        TargetAdventurer = new(context);
        TargetBoth = new(context);
    }

    internal TargetSelectionStrategy GetStrategy(SelectionStrategy selectionStrategy)
    {
        return selectionStrategy switch
        {
            SelectionStrategy.Enemy => TargetEnemy,
            SelectionStrategy.Adventurer => TargetAdventurer,
            SelectionStrategy.Both => TargetBoth,
            _ => NoTarget,

        };
    }
}
