using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameObject :MonoBehaviour
{
    [SerializeField]
    private bool canMoveInto;

    [SerializeField]
    private bool canBePushed;

    public bool CanMoveInto()
    {
        return canMoveInto;
    }
    public bool CanBePushed()
    {
        return canBePushed;

    }
    public virtual void ForceApplied(Vector2 direction)
    {
    }


}
