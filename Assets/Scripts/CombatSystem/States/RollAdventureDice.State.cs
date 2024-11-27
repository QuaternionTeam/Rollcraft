internal class RollAdventureDiceState : CombatSystemState
{
    public RollAdventureDiceState(CombatSystem context) : base(context) { }
    /*
    internal Adventurer adventurer;
    internal Face face;
    internal int faceIndex;
    internal bool HasToSelectEnemies =>
        face != null && face.EnemiesCount == TargetsCount.One;
    internal bool HighlightAdventurers =>
        face != null && face.AdventurersCount == TargetsCount.One;

    internal RollAdventureDiceState(CombatSystem context, Adventurer adventurer) : base(context)
    {
        this.adventurer = adventurer;
        (Face, int )tuple = adventurer.Dice.Roll();
        face = tuple.Item1;
        faceIndex = tuple.Item2;

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
        (Face, int )tuple = adventurer.Dice.Roll();
        face = tuple.Item1;
        faceIndex = tuple.Item2;
    }*/

}