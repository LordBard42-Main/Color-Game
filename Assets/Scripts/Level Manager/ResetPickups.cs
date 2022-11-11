using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPickups : MonoBehaviour
{
    private IReset iReset;

    private ColorPickup[] colorPickups;
    private void Awake()
    {
        iReset = GetComponent<IReset>();
    }

    // Start is called before the first frame update
    void Start()
    {
        iReset.OnLevelReset += ResetColors;
        colorPickups = FindObjectsOfType<ColorPickup>();
    }
    private void OnDestroy()
    {
        iReset.OnLevelReset -= ResetColors;
    }

    private void ResetColors()
    {
        foreach (var colorPickup in colorPickups)
        {
            colorPickup.Reset();
        }
    }
}
