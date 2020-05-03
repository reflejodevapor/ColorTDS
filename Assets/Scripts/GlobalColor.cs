using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalColor : MonoBehaviour
{

    public static Color red = Color.red;
    public static Color green = Color.green;
    public static Color blue = Color.blue;

    public Color RedColor = Color.red;
    public Color GreenColor = Color.green;
    public Color BlueColor = Color.blue;

    private void Update()
    {

            red = RedColor;
            green = GreenColor;
            blue = BlueColor;


    }




}