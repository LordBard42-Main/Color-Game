using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColorDictionaries
{
    public static readonly Dictionary<PrimaryColors, Color> primaryColors = new Dictionary<PrimaryColors, Color>
    {
        {PrimaryColors.White, Color.white },
        {PrimaryColors.Red, Color.red },
        {PrimaryColors.Blue, Color.blue},
        {PrimaryColors.Yellow, Color.yellow },
        {PrimaryColors.Purple, new Color(1,0,1,1)},
        {PrimaryColors.Orange, new Color(1,20/255f, 0,1)},
        {PrimaryColors.Green, Color.green },
        {PrimaryColors.Black, Color.black },
    };


}
