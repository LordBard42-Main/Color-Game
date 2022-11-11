using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColorDictionaries
{
    public static readonly Dictionary<Colors, Color> primaryColors = new Dictionary<Colors, Color>
    {
        {Colors.White, Color.white },
        {Colors.Red, Color.red },
        {Colors.Blue, Color.blue},
        {Colors.Yellow, Color.yellow },
        {Colors.Purple, new Color(1,0,1,1)},
        {Colors.Orange, new Color(1,20/255f, 0,1)},
        {Colors.Green, Color.green },
        {Colors.Black, Color.black },
    };


}
