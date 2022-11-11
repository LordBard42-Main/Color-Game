using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Updates the Players Pointer when the base object Color Changes
/// </summary>
public class PlayerColorController : ColorController
{
    [SerializeField]
    private Renderer pointerRenderer;

    public override void UpdateColor(Colors color)
    {
        base.UpdateColor(color);
        pointerRenderer.material.color = ColorDictionaries.primaryColors[color];
        pointerRenderer.gameObject.layer = ColorLayerMap[color];
    }


}
