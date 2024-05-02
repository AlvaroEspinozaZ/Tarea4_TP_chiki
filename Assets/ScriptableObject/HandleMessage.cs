using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Handle", menuName = "Handle/Message")]
public class HandleMessage : ScriptableObject
{
    public event Action<int> ActionGeneralInt;
    public event Action ActionGeneral;

    public void CallEventInt(int value)
    {
        ActionGeneralInt?.Invoke(value);
    }
    public void CallEventGeneral()
    {
        ActionGeneral?.Invoke();
    }
}
