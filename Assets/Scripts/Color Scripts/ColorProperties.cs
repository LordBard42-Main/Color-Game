using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum PrimaryColors { White = 1, Red = 3, Blue = 5, Yellow = 7, Purple = 15, Orange = 21, Green = 35, Black = 105, }
public enum SecondaryColors { Green, Orange, Purple}

public class ColorProperties : MonoBehaviour
{

    [SerializeField] 
    private PrimaryColors startColor;

    private List<PrimaryColors> colorList = new List<PrimaryColors>();

    private PrimaryColors currentColor;

    public delegate void ColorChange(PrimaryColors currentColor);
    public ColorChange OnColorChangeEvent;

    public delegate void ColorAdded(PrimaryColors currentColor);
    public ColorAdded OnColorAdded;

    public delegate void ColorRemoved(PrimaryColors currentColor);
    public ColorRemoved OnColorRemoved;

    public PrimaryColors CurrentColor { get => currentColor; set => currentColor = value; }
    public PrimaryColors StartColor { get => startColor; }
    public List<PrimaryColors> ColorList { get => colorList; }

    private void Awake()
    {
        currentColor = PrimaryColors.White;
    }

    private void Start()
    {
        AddColor(StartColor);
    }

    /// <summary>
    /// Updates the objects color and the layer its on
    /// </summary>
    /// <param name="value"></param>
    public void UpdateColor(int value)
    {
        currentColor = (PrimaryColors)value;
        OnColorChangeEvent?.Invoke(currentColor);
    }

    public virtual bool AddColor(PrimaryColors color)
    {
        var canPerformColorOperation = ColorAdditionAllowed(color);

        if (canPerformColorOperation)
        {
            var newColor = ColorAddition(color);

            if(currentColor != PrimaryColors.White)
            {
                ColorList.Add(color);
            }
            ColorList.Add(newColor);
            currentColor = newColor;
            OnColorChangeEvent?.Invoke(currentColor);
            OnColorAdded?.Invoke(color);
            SetColorComposition();
        }

        return canPerformColorOperation;

    }

    public virtual bool RemoveColor(PrimaryColors color)
    {
        var canPerformColorOperation = ColorSubtractionAllowed(color);

        if (canPerformColorOperation)
        {
            var newColor = ColorSubtraction(color);
            currentColor = newColor;
            OnColorChangeEvent?.Invoke(currentColor);
            OnColorRemoved?.Invoke(color);
            SetColorComposition();
        }

        return canPerformColorOperation;
    }

    private PrimaryColors ColorAddition(PrimaryColors color)
    {
        var newColor = (PrimaryColors)((int)currentColor * (int)color);
        return newColor;
    }
    private PrimaryColors ColorSubtraction(PrimaryColors color)
    {
        if ((int)currentColor > 10)
            colorList.Remove(currentColor);
        var newColor = (PrimaryColors)((int)currentColor / (int)color);
        colorList.Remove(color);
        return newColor;
    }

    private bool ColorSubtractionAllowed(PrimaryColors color)
    {
        var color1Value = (int)color;
        var color2Value = (int)currentColor;

        return color2Value % color1Value == 0;

    }

    private bool ColorAdditionAllowed(PrimaryColors color)
    {
        var notSameColor = currentColor != color;
        var notColorChild = ((int)currentColor % (int)color) != 0;
        return notSameColor && notColorChild;

    }

    private void SetColorComposition()
    {

        colorList.Clear();

        //Purple
        if (currentColor == PrimaryColors.Purple)
        {
            colorList.Add(PrimaryColors.Red);
            colorList.Add(PrimaryColors.Blue);
        }
        //Orange
        if (currentColor == PrimaryColors.Orange)
        {
            colorList.Add(PrimaryColors.Red);
            colorList.Add(PrimaryColors.Yellow);
        }
        //Green
        if (currentColor == PrimaryColors.Green)
        {
            colorList.Add(PrimaryColors.Blue);
            colorList.Add(PrimaryColors.Yellow);
        }

        colorList.Add(currentColor);
    }


}
