using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool healthBar = false;

    public float unitHealth = 100.0f;

    float DamageResistance = 65.0f;

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
        if(unitHealth < 0)
        {
            Destroy(this.gameObject);
        }



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
