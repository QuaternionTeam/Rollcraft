using System.Collections.Generic;
using UnityEngine;

internal class Grid<T>
{
    internal readonly Vector2Int size;
    private readonly float cellSize;
    private readonly T[,] cells;

    internal Grid(Vector2Int size, float cellSize)
    {
        this.size = size;
        this.cellSize = cellSize;
        cells = new T[size.x, size.y];
    }

    internal Vector2 WorldSize => new Vector2(size.x, size.y) * cellSize;

    internal Vector2 CellWorldPosition(Vector2Int gridPosition) => new Vector2(gridPosition.x, gridPosition.y) * cellSize;
    internal Vector2 CellWorldPositionCentered(Vector2Int gridPosition) => CellWorldPosition(gridPosition) + Vector2.one * cellSize / 2;

    internal T GetCell(Vector2Int gridPosition) => cells[gridPosition.x, gridPosition.y];

    internal void SetCell(Vector2Int gridPosition, T cell)
    {
        cells[gridPosition.x, gridPosition.y] = cell;
    }

    public IEnumerable<(Vector2Int, T)> Cells()
    {
        for (int gridPositionX = 0; gridPositionX < size.x; gridPositionX++)
            for (int gridPositionY = 0; gridPositionY < size.y; gridPositionY++)
                yield return (new Vector2Int(gridPositionX, gridPositionY), cells[gridPositionX, gridPositionY]);

    }
}
