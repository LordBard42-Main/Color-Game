using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode
{
    private IGameObject occupyingGridObject;

    public IGameObject OccupyingGridObject { get => occupyingGridObject; }

    public void SetOccupyingGridObject(IGameObject gridObject)
    {
        occupyingGridObject = gridObject;
    }

    public IGameObject GetOccupyingGridObject()
    {
        return occupyingGridObject;
    }
}
