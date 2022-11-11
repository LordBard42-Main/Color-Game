using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Colors { White = 1, Red = 3, Blue = 5, Yellow = 7, Purple = 15, Orange = 21, Green = 35, Black = 105, }

/// <summary>
/// This Class Handles an Objects Current Color AND the Adding/Removing Colors From it
/// </summary>
public class ColorProperties : MonoBehaviour
{

    [SerializeField] 
    private Colors startColor;
    private Colors currentColor;
    private List<Colors> colorList = new List<Colors>();


    public delegate void ColorChange(Colors currentColor);
    public ColorChange OnColorChangeEvent;

    public delegate void ColorAdded(Colors currentColor);
    public ColorAdded OnColorAdded;

    public delegate void ColorRemoved(Colors currentColor);
    public ColorRemoved OnColorRemoved;

    public Colors CurrentColor { get => currentColor; }
    public Colors StartColor { get => startColor; }
    public List<Colors> ColorList { get => colorList; }

    private void Awake()
    {
        //Set default currentColor to avoid error on init
        currentColor = Colors.White;
    }

    public bool CheckIfColorCanBeAdded(Colors color)
    {
        var notSameColor = currentColor != color;
        var notColorChild = ((int)currentColor % (int)color) != 0;
        var addingCompositeColorToNonWhite = (int)color > 10 && currentColor != Colors.White || 
            ((int)currentColor > 10 && color != Colors.White);
        return notSameColor && notColorChild && !addingCompositeColorToNonWhite;
    }

    /// <summary>
    /// Adds Color to the ColorProperty
    /// </summary>
    /// <param name="color"></param>
    public void AddColor(Colors color)
    {
        currentColor = ColorAddition(color);
        OnColorChangeEvent?.Invoke(currentColor);
        SetColorComposition();
    }
    public bool CheckIfColorCanBeRemoved(Colors color)
    {
        var color1Value = (int)color;
        var color2Value = (int)currentColor;

        return color2Value % color1Value == 0;

    }

    /// <summary>
    /// Removes Color from the ColorProperty
    /// </summary>
    /// <param name="color"></param>
    public void RemoveColor(Colors color)
    {
        currentColor = ColorSubtraction(color);
        OnColorChangeEvent?.Invoke(currentColor);
        SetColorComposition();
    }

    private Colors ColorAddition(Colors color)
    {
        var newColor = (Colors)((int)currentColor * (int)color);
        return newColor;
    }

    private Colors ColorSubtraction(Colors color)
    {
        //If Current Color is a Composite Color, remove it from the list
        if ((int)currentColor > 10)
            colorList.Remove(currentColor);

        var newColor = (Colors)((int)currentColor / (int)color);
        colorList.Remove(color);
        return newColor;
    }

    /// <summary>
    /// Places all the colors available that the object is
    /// composed into the Color List
    /// </summary>
    private void SetColorComposition()
    {

        colorList.Clear();

        //Purple
        if (currentColor == Colors.Purple)
        {
            colorList.Add(Colors.Red);
            colorList.Add(Colors.Blue);
        }
        //Orange
        if (currentColor == Colors.Orange)
        {
            colorList.Add(Colors.Red);
            colorList.Add(Colors.Yellow);
        }
        //Green
        if (currentColor == Colors.Green)
        {
            colorList.Add(Colors.Blue);
            colorList.Add(Colors.Yellow);
        }

        colorList.Add(currentColor);
    }

    public void ResetToWhite()
    {
        colorList.Clear();
        currentColor = Colors.White;
        AddColor(Colors.White);
    }

    public void ResetToStartingColor()
    {
        ResetToWhite();
        AddColor(StartColor);
    }

}
