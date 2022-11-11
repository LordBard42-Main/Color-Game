using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWall : IGameObject
{

    private ColorProperties colorProperties;

    private void Awake()
    {
        colorProperties = GetComponent<ColorProperties>();
    }

    public void Reset()
    {
        colorProperties.ResetToStartingColor();
    }
}
