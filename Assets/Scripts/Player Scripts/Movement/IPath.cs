using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPath
{
    public Stack<Vector2> GetPath(Vector2 startPoint, Vector2 endPoint);
}
