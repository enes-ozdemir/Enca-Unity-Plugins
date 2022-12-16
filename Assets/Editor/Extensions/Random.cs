using System;
using System.Collections.Generic;
using Editor.Extensions;

public static class Random
{
    public static float GetRandomNumber(float limitNumber) => UnityEngine.Random.Range(0, limitNumber);

    // public static float GetWeightedRandomNumber(float limitNumber, float weightTowards, float weightPower)
    // {
    // }


    
}