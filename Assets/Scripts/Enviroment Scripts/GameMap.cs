using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{

    [SerializeField]
    private Transform playerPrefab;

    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    [SerializeField]
    private int cellSize;
    [SerializeField]
    private Vector2Int origin;

    [SerializeField]
    private Vector2Int playerStart;



    private Grid grid;

    void Awake()
    {
        grid = new Grid(width, height, cellSize, origin);
    }

    private void Start()
    {
        SetPlayerOnStart();
    }

    private void SetPlayerOnStart()
    {
        var player = Instantiate(playerPrefab, new Vector2(playerStart.x, playerStart.y), Quaternion.identity).GetComponent<IGameObject>();
        grid.AddObjectToGrid(playerStart, player);
    }
}
