using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWallsReset : MonoBehaviour
{
    private IReset iReset;

    private ColorWall[] colorWalls;
    private void Awake()
    {
        iReset = GetComponent<IReset>();
    }

    // Start is called before the first frame update
    void Start()
    {
        iReset.OnLevelReset += ResetColors;
        colorWalls = FindObjectsOfType<ColorWall>();
    }
    private void OnDestroy()
    {
        iReset.OnLevelReset -= ResetColors;
    }

   private void ResetColors()
    {
        foreach (var colorWall in colorWalls)
        {
            colorWall.Reset();
        }
    }
}
