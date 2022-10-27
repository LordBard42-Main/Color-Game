using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid
{
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    [SerializeField]
    int cellSize;
    [SerializeField]
    Vector2Int origin;




    private GridNode[,] gridArray;


    public Grid(int width, int height, int cellSize, Vector2Int origin)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = origin;

        gridArray = new GridNode[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridArray[x, y] = new GridNode();
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x + origin.x, y + origin.y) * cellSize;
    }

    public void AddObjectToGrid(Vector2Int location, IGameObject gridObject)
    {
        gridArray[location.x, location.y].SetOccupyingGridObject(gridObject);

    }

}
