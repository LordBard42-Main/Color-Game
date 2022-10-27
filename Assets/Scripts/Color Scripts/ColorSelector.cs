using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorSelectorUI))]
public class ColorSelector : MonoBehaviour
{

    private List<PrimaryColors> colorList = new List<PrimaryColors>();

    public delegate void ColorSlotUpdated(PrimaryColors color);
    public event ColorSlotUpdated OnColorSlotAdded;
    public event ColorSlotUpdated OnColorSlotRemoved;

    public delegate void UpdateColorSelectVisibility(Vector2 position, bool isOpen, ColorProperties colorProperties);
    public event UpdateColorSelectVisibility OnUpdatedColorSelectVisibility;

    public delegate void ColorSelected(PrimaryColors color);
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

    public void SelectColor(PrimaryColors color)
    {
        CloseColorSelection();
        OnColorSelected?.Invoke(color);
    }
}
