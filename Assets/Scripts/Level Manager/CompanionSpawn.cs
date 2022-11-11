using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionSpawn : MonoBehaviour
{
    private IReset iReset;

    [SerializeField]
    private bool spawnCompanion;

    [SerializeField]
    Vector2 companionStartLocation;

    [SerializeField]
    private Colors startingColor;

    [SerializeField]
    private Transform companionPrefab;

    private Transform currentCompanion;

    private void Awake()
    {
        iReset = GetComponent<IReset>();
    }

    private void Start()
    {
        iReset.OnLevelReset += SetSpawn;
        SetSpawn();
    }

    private void OnDestroy()
    {
        iReset.OnLevelReset -= SetSpawn;
    }

    public void SetSpawn()
    {

        if (currentCompanion != null)
            Destroy(currentCompanion.gameObject);

        if(spawnCompanion)
        {
            currentCompanion = Instantiate(companionPrefab);
            var companionMovementController = currentCompanion.GetComponentInChildren<CompanionMovementController>();
            var companionColorProperties = currentCompanion.GetComponentInChildren<ColorProperties>();
            companionMovementController.TeleportPlayer(companionStartLocation);
            companionColorProperties.ResetToWhite();
            companionColorProperties.AddColor(startingColor);
        }
    }

}
