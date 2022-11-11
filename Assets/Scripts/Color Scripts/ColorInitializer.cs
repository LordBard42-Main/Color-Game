using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes Colorobjects on scene start
/// </summary>
public class ColorInitializer : MonoBehaviour
{
    private ColorProperties colorProperties;


    private void Awake()
    {
        colorProperties = GetComponent<ColorProperties>();
    }

    private void Start()
    {
        colorProperties.ResetToWhite();
        colorProperties.ResetToStartingColor();
    }
}
