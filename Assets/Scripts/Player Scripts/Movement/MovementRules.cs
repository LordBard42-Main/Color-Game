using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRules : MonoBehaviour
{
    [SerializeField]
    private ColorProperties colorProperties;


    private readonly int GRIDSCALE = 1;


    public Tuple<bool,Vector2> CheckMovement(Vector2 startPosition, Vector2 direction)
    {
        var hit = Physics2D.Raycast(startPosition + (direction * .5f), direction, GRIDSCALE - .1f);
        Vector2 destination;

        if (hit)
        {
            var isSpaceBlocked = IsSpaceBlocked(hit);
            var objectsColorProperties = DoesObjectHaveColorProperties(hit);
            var pickupObject = IsObjectAPickup(hit);

            if(isSpaceBlocked)
                return new Tuple<bool, Vector2>(false, default(Vector2));

            if (objectsColorProperties != null)
            {
                if(pickupObject != null)
                {
                    destination = startPosition + direction;
                    return new Tuple<bool, Vector2>(true, destination);
                }

                var colorsMatch = objectsColorProperties.CurrentColor == colorProperties.CurrentColor;
                if (colorsMatch)
                {
                    destination = startPosition + direction;
                    return new Tuple<bool, Vector2>(true, destination);
                }
                return new Tuple<bool, Vector2>(false, default(Vector2));
            }
            
        }

        destination = startPosition + direction;
        return new Tuple<bool, Vector2>(true, destination);
    }
    private bool IsSpaceBlocked(RaycastHit2D hit)
    {
        if (hit.transform.TryGetComponent(out IGameObject hitObject))
        {
            return !hitObject.CanMoveInto();
        }

        return false;
    }

    private ColorProperties DoesObjectHaveColorProperties(RaycastHit2D hit)
    {
            var hitObject = hit.transform.GetComponent<ColorProperties>();
            return hitObject;
        
    }

    private IPickup IsObjectAPickup(RaycastHit2D hit)
    {
        return hit.transform.GetComponent<IPickup>();
    }
}
