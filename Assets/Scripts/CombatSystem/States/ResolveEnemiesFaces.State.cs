internal class ResolveEnemiesFacesState : CombatSystemState
{
    public ResolveEnemiesFacesState(CombatSystem context) : base(context)
    {
        foreach(Face face in context.enemyFaces)
        {
            face.ApplyEffect();
            if(context.adventurers.Count == 0)
            {
                //TODO: LOSE
            }
        }
        
        context.ChangeState(new EnemyRollState(context));
    }
}
