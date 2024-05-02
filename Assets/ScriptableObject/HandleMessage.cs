using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Handle", menuName = "Handle/Message")]
public class HandleMessage : ScriptableObject
{
    public event Action<int> ActionGeneral;

    public void CallEvent(int value)
    {
        ActionGeneral?.Invoke(value);
    }
}
