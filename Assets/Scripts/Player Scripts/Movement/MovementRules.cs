using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRules
{

    private readonly int GRIDSCALE = 1;

    public Tuple<bool,Vector2> CheckMovement(Vector2 startPosition, Vector2 direction, ColorProperties colorProperties)
    {
        var hit = Physics2D.Raycast(startPosition + (direction * .5f), direction, GRIDSCALE - .1f);
        Vector2 destination;

        if (hit)
        {
            var isSpaceBlocked = IsSpaceBlocked(hit);
            var objectsColorProperties = DoesObjectHaveColorProperties(hit);
            var pickupObject = IsObjectAPickup(hit);
            var stoppedDueToPushableObjectCollision = !HitPushableObject(hit, direction);

            ///If Player cannot move into space, return false
            if(isSpaceBlocked && stoppedDueToPushableObjectCollision)
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

    /// <summary>
    /// Checks to see if there is an object the player 
    /// cannot move into ahead.
    /// </summary>
    /// <param name="hit"></param>
    /// <returns></returns>
    private bool IsSpaceBlocked(RaycastHit2D hit)
    {
        if (hit.transform.TryGetComponent(out IGameObject hitObject))
        {
            return !hitObject.CanMoveInto();
        }

        return false;
    }

    /// <summary>
    /// Retrieves Objects Color Properties if it has it
    /// </summary>
    /// <param name="hit"></param>
    /// <returns></returns>
    private ColorProperties DoesObjectHaveColorProperties(RaycastHit2D hit)
    {
            var hitObject = hit.transform.GetComponent<ColorProperties>();
            return hitObject;
        
    }

    /// <summary>
    /// Checks if the Object is a pickup
    /// </summary>
    /// <param name="hit"></param>
    /// <returns></returns>
    private IPickup IsObjectAPickup(RaycastHit2D hit)
    {
        return hit.transform.GetComponent<IPickup>();
    }
    private bool HitPushableObject(RaycastHit2D hit, Vector2 force)
    {
        if (hit.transform.TryGetComponent(out IGameObject hitObject))
        {
            var isObjectPushable = hitObject.CanBePushed();

            if (isObjectPushable)
                hitObject.ForceApplied(force);

            return isObjectPushable;
        }

        return false;
    }
}
