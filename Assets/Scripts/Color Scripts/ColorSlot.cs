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
    private PrimaryColors slotColor;

    private ColorSelector colorSelector;

    [SerializeField]
    private Button slotButton;

    private ColorBlock buttonColorBlock;

    public delegate void SlotPressed();
    public event SlotPressed OnSlotPressed;

    private readonly Dictionary<PrimaryColors, int> hValueMap = new Dictionary<PrimaryColors, int>
    {
        {PrimaryColors.White, 300},
        {PrimaryColors.Red, 1 },
        {PrimaryColors.Blue, 240},
        {PrimaryColors.Yellow, 60 },
        {PrimaryColors.Purple, 275},
        {PrimaryColors.Orange, 30},
        {PrimaryColors.Green, 110 },
        {PrimaryColors.Black, 300 },
    };


    public void CreateSlot(PrimaryColors color, ColorSelector colorSelector)
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
        Debug.Log("Slot Set");
    }

    public void ButtonPressed()
    {
        colorSelector.SelectColor(slotColor);
    }

}
