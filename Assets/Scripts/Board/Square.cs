using UnityEngine;

public abstract class Square : MonoBehaviour
{
    [SerializeField] internal int gridPosX, gridPosY;
    internal Board board;

    internal void Initialize(Board board, int gridPosX, int gridPosY)
    {
        this.board = board;
        this.gridPosX = gridPosX;
        this.gridPosY = gridPosY;
    }

    internal abstract bool Walkable();
    internal abstract void OnMouseDown();
    internal abstract SquareType Type();

    internal void ActivateGlow()
    {
        Animation animation = GetComponentInChildren<Animation>();
        if (animation)
            animation.Play();
    }
}
