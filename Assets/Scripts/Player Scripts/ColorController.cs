using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{

    private new Renderer renderer;
    protected ColorProperties colorProperties;

    protected readonly Dictionary<PrimaryColors, int> ColorLayerMap = new Dictionary<PrimaryColors, int>
    {
        {PrimaryColors.White, 8},
        {PrimaryColors.Red, 9 },
        {PrimaryColors.Blue, 10},
        {PrimaryColors.Yellow, 11 },
        {PrimaryColors.Purple, 12},
        {PrimaryColors.Orange, 13},
        {PrimaryColors.Green, 14 },
        {PrimaryColors.Black, 15 },
    };

    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        colorProperties = GetComponent<ColorProperties>();
        colorProperties.OnColorChangeEvent += UpdateColor;
    }

    public virtual void Start()
    {


        var startColor = colorProperties.StartColor;
        renderer.material.color = ColorDictionaries.primaryColors[startColor];
        gameObject.layer = ColorLayerMap[startColor];

    }

    public virtual void UpdateColor(PrimaryColors color)
    {
        renderer.material.color = ColorDictionaries.primaryColors[color];
        gameObject.layer = ColorLayerMap[color];

    }
}
