using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWall : MonoBehaviour, IGameObject
{
    ColorProperties colorProperties;

    [SerializeField]
    private bool canMoveInto;

    private void Awake()
    {
        colorProperties = GetComponent<ColorProperties>();
    }

    public bool CanMoveInto()
    {
        return canMoveInto;
    }
  
}
