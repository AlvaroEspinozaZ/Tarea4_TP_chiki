using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameEventListeners : MonoBehaviour
{
    public GameEvent eventsss;

    public UnityEvent response;
    public UnityEvent<int> responseInt;
    public UnityEvent<float> responseFloat;


    private void OnEnable()
    {
        eventsss.Register(this);        
    }
    private void OnDisable()
    {
        eventsss.Unregister(this);
    }
    public void OnEventRaise()
    {
        response?.Invoke();
    }
    public void OnEventRaise(int i)
    {
        responseInt?.Invoke(i);
    }
    public void OnEventRaise(float i)
    {
        responseFloat?.Invoke(i);
    }
}
