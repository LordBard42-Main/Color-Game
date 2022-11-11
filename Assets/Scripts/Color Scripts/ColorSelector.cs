using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorSelectorUI))]
public class ColorSelector : MonoBehaviour
{

    private List<Colors> colorList = new List<Colors>();

    public delegate void ColorSlotUpdated(Colors color);
    public event ColorSlotUpdated OnColorSlotAdded;
    public event ColorSlotUpdated OnColorSlotRemoved;

    public delegate void UpdateColorSelectVisibility(Vector2 position, bool isOpen, ColorProperties colorProperties);
    public event UpdateColorSelectVisibility OnUpdatedColorSelectVisibility;

    public delegate void ColorSelected(Colors color);
    public event ColorSelected OnColorSelected;

    private ColorProperties colorProperties;


    public void OpenColorSelection(Vector2 position, ColorProperties colorProperties)
    {
        OnUpdatedColorSelectVisibility?.Invoke(position,true, colorProperties);
        this.colorProperties = colorProperties;
    }

    public void CloseColorSelection()
    {
        OnUpdatedColorSelectVisibility?.Invoke(new Vector2(0,0), false, colorProperties);
        colorProperties = null;
    }

    public void SelectColor(Colors color)
    {
        CloseColorSelection();
        OnColorSelected?.Invoke(color);
    }
}
