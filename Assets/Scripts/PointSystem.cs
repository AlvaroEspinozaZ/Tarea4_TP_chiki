using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PointSystem : MonoBehaviour
{
    public static Action<int> GainsPoint;
    public static Action<int> UpdatePoints;
    [Header("GlobalValues")]
    [SerializeField] public GlobalValues score;
    public int points=0;
    [Header("Handlers")]
    [SerializeField] private HandleMessage updatePoints;
    
    private void Awake()
    {
        //GainsPoint = CurrentPoints;
        //UpdatePoints = CurrentPoints;
        updatePoints.ActionGeneralInt += CurrentPoints;
    }
    private void CurrentPoints(int pnts)
    {
        score.ValueInt += pnts;
    }
}
