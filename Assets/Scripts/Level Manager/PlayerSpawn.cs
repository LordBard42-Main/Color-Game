using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    private IReset iReset;

    Vector2 playerStartLocation;
    private Colors startingColor;

    [SerializeField]
    private Transform player;

    private void Awake()
    {
        iReset = GetComponent<IReset>();
    }

    private void Start()
    {
        playerStartLocation = player.GetComponent<PlayerMovementController>().Position;
        startingColor = player.GetComponentInChildren<ColorProperties>().StartColor;
        iReset.OnLevelReset += SetSpawn;
        SetSpawn();
    }

    private void OnDestroy()
    {
        iReset.OnLevelReset -= SetSpawn;
    }

    public void SetSpawn()
    {
        var playerMovementController = player.GetComponent<PlayerMovementController>();
        var playerColorProperties = player.GetComponentInChildren<ColorProperties>();
        playerMovementController.TeleportPlayer(playerStartLocation);
        playerColorProperties.ResetToWhite();
        playerColorProperties.AddColor(startingColor);
    }

}
