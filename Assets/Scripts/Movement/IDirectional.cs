using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectional 
{
    public delegate void DirectionUpdated(Vector2 direction);
    public event DirectionUpdated OnDirectionUpdated;
}
