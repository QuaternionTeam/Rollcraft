using UnityEngine;

internal class DieStaticInitial : DieState
{
    internal DieStaticInitial(Die die) : base(die) { }

    
    internal override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Roll();
    }
    
    
    internal override void Roll()
    {
        base.Roll();
        die.ChangeState(DieStates.Rolling);
    }
}