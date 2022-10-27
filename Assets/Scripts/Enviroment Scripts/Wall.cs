using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IGameObject
{
    [SerializeField]
    private bool canMoveInto;
    public bool CanMoveInto()
    {
        return canMoveInto;
    }

}
