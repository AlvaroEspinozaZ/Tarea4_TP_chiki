using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PointSystem : MonoBehaviour
{
    public static Action<int> GainsPoint;
    public static Action<int> UpdatePoints;
    public int points=0;

    private void Awake()
    {
        GainsPoint = CurrentPoints;
        UpdatePoints = CurrentPoints;
    }
    private void CurrentPoints(int pnts)
    {
        points += pnts;
    }
}
