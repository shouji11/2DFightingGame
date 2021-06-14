using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easing 
{
    public static float sineIn(float time, float min, float max, float total)
    {
        max -= min;

        return -max / 2 * (Mathf.Sin(time * Mathf.PI / total) - 1) + min;
    }


 
}
