using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorController : ColorController
{
    [SerializeField]
    private Renderer pointerRenderer;

    [SerializeField]
    private ColorSelector colorSelector;


    public override void Start()
    {
        base.Start(); 
        var startColor = colorProperties.StartColor;
        pointerRenderer.material.color = ColorDictionaries.primaryColors[startColor];
        gameObject.layer = ColorLayerMap[startColor];

        colorProperties.OnColorAdded += ColorAdded;
        colorProperties.OnColorRemoved += ColorRemoved;

    }

    private void OnDestroy()
    {
        colorProperties.OnColorAdded -= ColorAdded;
        colorProperties.OnColorRemoved -= ColorRemoved;
    }

    public override void UpdateColor(PrimaryColors color)
    {
        base.UpdateColor(color);
        pointerRenderer.material.color = ColorDictionaries.primaryColors[color];
        pointerRenderer.gameObject.layer = ColorLayerMap[color];
    }


    public void ColorAdded(PrimaryColors color)
    {

    }
    public void ColorRemoved(PrimaryColors color)
    {

    }

}
