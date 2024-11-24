internal class RollAdventureDiceState : CombatSystemState
{
    internal Adventurer adventurer;
    internal Face face;
    internal bool HasToSelectEnemies =>
        face != null && face.EnemiesCount == TargetsCount.One;
    internal bool HighlightAdventurers =>
        face != null && face.AdventurersCount == TargetsCount.One;

    internal RollAdventureDiceState(CombatSystem context, Adventurer adventurer) : base(context)
    {
        this.adventurer = adventurer;
        face = adventurer.Dice.Roll();

        //TODO TURN ON REROLL BUTTON

        //TODO TURN ON TARGETS HIGHLIGHTS
    }

    internal override void HasBeenClicked(Unit unit) 
    {        
        if(unit is Adventurer adventurer)
            face.adventurerTarget = adventurer;

        if(unit is Enemy enemy)
            face.enemyTarget = enemy;

        if(face.HasAllTargetsSelected())
            {}//TODO TURN ON Confirm Button
    }

    internal override void Confirm()
    {
        base.Confirm();

        if(face.HasAllTargetsSelected())
            context.ChangeState(new ResolveAdventurerFaceState(context, face));
    }

    internal override void Reroll()
    {
        face = adventurer.Dice.Roll();
    }
}