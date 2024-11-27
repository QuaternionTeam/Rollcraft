internal class ResolveAdventurerFaceState : CombatSystemState
{
    public ResolveAdventurerFaceState(CombatSystem context, Face face) : base(context) 
    { 
        face.Resolve();

        //if(CombatSystem.enemies.Count == 0)
            //TODO: WIN!
        

        context.ChangeState(new ChooseAdveturersState(context));
        
    }

    
}