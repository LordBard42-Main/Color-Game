using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Version of Color Controller.
/// can be inherited from for expanded functionality
/// </summary>
public class ColorController : MonoBehaviour
{

    private new Renderer renderer;
    protected ColorProperties colorProperties;

    ///Maps an Objects Color to the integer Value of the matching Layer
    protected readonly Dictionary<Colors, int> ColorLayerMap = new Dictionary<Colors, int>
    {
        {Colors.White, 8},
        {Colors.Red, 9 },
        {Colors.Blue, 10},
        {Colors.Yellow, 11 },
        {Colors.Purple, 12},
        {Colors.Orange, 13},
        {Colors.Green, 14 },
        {Colors.Black, 15 },
    };

    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        colorProperties = GetComponent<ColorProperties>();
        colorProperties.OnColorChangeEvent += UpdateColor;
    }
    /// <summary>
    /// Object is updated when it's color is updated
    /// </summary>
    /// <param name="color"></param>
    public virtual void UpdateColor(Colors color)
    {
        renderer.material.color = ColorDictionaries.primaryColors[color];
        gameObject.layer = ColorLayerMap[color];

    }
}
