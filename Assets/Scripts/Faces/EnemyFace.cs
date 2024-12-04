using UnityEngine;

internal class EnemyFace : Face
{
    [SerializeField] private SkillStrategy OnLandSkill;
    [SerializeField] private SkillStrategy Skill;

    internal override SelectionStrategy Target => Skill.Target;

    internal override void OnLand()
    {
        OnLandSkill.Resolve();
    }

    internal override void Resolve()
    {
        Skill.Resolve();
    }
}