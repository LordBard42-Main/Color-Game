using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour, IPath
{

    public Stack<Vector2> GetPath(Vector2 location, Vector2 direction)
    {
        location += direction;
        direction *= -1;

        var path = new Stack<Vector2>();

        if (direction.x != 0)
        {
            path.Push(new Vector2(direction.x, 0));
        }
        else if (direction.y != 0)
        {
            path.Push(new Vector2(0, direction.y));
        }

        return path;

    }



}
