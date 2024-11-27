using UnityEngine;

internal class DieLandingState: DieState
{
    internal readonly Transform cube; 

    internal DieLandingState(Die die) : base(die) 
    { 
        cube = die.transformComponent;
    }

    internal override void Enter()
    {
        base.Enter();

        int faceIndex = Random.Range(0, die.faces.Length);

        Face faceToLandOn = die.faces[faceIndex];

        Debug.Log("Land on " + (faceIndex + 1));
        
        faceToLandOn.OnLand();

        Vector3 rotation = GetTargetRotationForFace(faceIndex + 1);

        cube.rotation = Quaternion.Euler(rotation);

        die.ChangeState(DieStates.Static);
    }

    Vector3 GetTargetRotationForFace(int face)
    {
        return face switch
        {
            1 => new Vector3(0, 0, 0),
            2 => new Vector3(0, 90, 0),
            3 => new Vector3(-90, 0, 0),
            4 => new Vector3(90, 0, 0),
            5 => new Vector3(0, -90, 0),
            6 => new Vector3(0, 180, 0),
            _ => Vector3.zero,
        };
    }
}