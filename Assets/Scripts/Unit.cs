using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool healthBar = false;


    public enum CurrentColor
    {
        red,
        green,
        blue
    }

    public CurrentColor unitColor;

    public Color color;

    private void Update()
    {
        switch (unitColor)
        {
            case CurrentColor.red:
                color = GlobalColor.red;
                break;
            case CurrentColor.green:
                color = GlobalColor.green;
                break;
            case CurrentColor.blue:
                color = GlobalColor.blue;
                break;

            default:break;
        }
    }


}
