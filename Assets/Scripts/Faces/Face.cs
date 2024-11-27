internal class Face
{
    //internal int diceIndex;

    internal SkillStrategy OnLandSkill = new NothingStrategy();
    internal SkillStrategy NeutralSkill = new NothingStrategy();
    internal SkillStrategy FastSkill = new NothingStrategy();
    internal SkillStrategy SlowSkill = new NothingStrategy();

    internal void OnLand()
    {
        OnLandSkill.Resolve();
    }

    internal void Resolve()
    {
        FastSkill.Resolve();
        SlowSkill.Resolve();
        
        NeutralSkill.Resolve();
    }
}
