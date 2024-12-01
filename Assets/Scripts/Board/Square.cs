using UnityEngine;

public abstract class Square : MonoBehaviour
{
    [SerializeField] internal Vector2Int gridPosition;
    internal Board board;

    internal void Initialize(Board board, Vector2Int gridPosition)
    {
        this.board = board;
        this.gridPosition = gridPosition;
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
