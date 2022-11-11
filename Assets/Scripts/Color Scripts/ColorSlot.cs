using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class ColorSlot : MonoBehaviour
{
    [SerializeField]
    private Colors slotColor;

    private ColorSelector colorSelector;

    [SerializeField]
    private Button slotButton;

    private ColorBlock buttonColorBlock;

    public delegate void SlotPressed();
    public event SlotPressed OnSlotPressed;

    private readonly Dictionary<Colors, int> hValueMap = new Dictionary<Colors, int>
    {
        {Colors.White, 300},
        {Colors.Red, 1 },
        {Colors.Blue, 240},
        {Colors.Yellow, 60 },
        {Colors.Purple, 275},
        {Colors.Orange, 30},
        {Colors.Green, 110 },
        {Colors.Black, 300 },
    };


    public void CreateSlot(Colors color, ColorSelector colorSelector)
    {
        slotColor = color;
        this.colorSelector = colorSelector;
        buttonColorBlock = slotButton.colors;
       

        var hValue = hValueMap[color];
        var sValue = 1;
        var vValueNormal = 100;
        var vValueHighlighted = 75;
        var vValuePressed = 50;


        buttonColorBlock.normalColor = Color.HSVToRGB(hValue/360f, sValue, vValueNormal/100f);
        buttonColorBlock.highlightedColor = Color.HSVToRGB(hValue / 360f, sValue, vValueHighlighted/100f);
        buttonColorBlock.pressedColor = Color.HSVToRGB(hValue / 360f, sValue, vValuePressed/100f);
        buttonColorBlock.selectedColor = Color.HSVToRGB(hValue / 360f, sValue, vValuePressed/100f);
        buttonColorBlock.pressedColor = Color.HSVToRGB(hValue / 360f, sValue, vValuePressed/100f);

        slotButton.colors = buttonColorBlock;
    }

    public void ButtonPressed()
    {
        colorSelector.SelectColor(slotColor);
    }

}
