using UnityEngine;

internal class DieRollingState: DieState
{
    internal readonly Transform cube;

    private readonly float rollDuration = 1.2f;
    private float rollTime = 0f;

    private Vector3 initialRotation;
    private Vector3 targetRotation; 

    internal DieRollingState(Die die) : base(die) 
    { 
        cube = die.transformComponent;
    }

    internal override void Update()
    {
        rollTime += Time.deltaTime;

        float lerpFactor = Mathf.Clamp01(rollTime / rollDuration);
        Vector3 currentRotation = Vector3.Lerp(initialRotation, targetRotation, lerpFactor);

        cube.rotation = Quaternion.Euler(currentRotation);

        if (rollTime > rollDuration)
            die.ChangeState(DieStates.Landing);
    }

    internal override void Enter()
    {
        base.Enter();

        rollTime = 0f;

        Debug.Log("Roll!");

        initialRotation = cube.rotation.eulerAngles;

        targetRotation = new Vector3(
            Random.Range(490f * rollDuration, 850f * rollDuration), 
            Random.Range(490f * rollDuration, 850f * rollDuration), 
            Random.Range(490f * rollDuration, 850f * rollDuration)
        );
    }
}