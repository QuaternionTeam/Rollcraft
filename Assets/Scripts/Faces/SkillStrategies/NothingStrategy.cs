using UnityEngine;

[CreateAssetMenu(fileName = "NothingSkill", menuName = "Skills/NothingSkill")]
internal class NothingStrategy : SkillStrategy
{
    //internal override Unit Unit => null;

    internal override void Resolve()
    {
        Debug.Log("I did nothing");
    }
}