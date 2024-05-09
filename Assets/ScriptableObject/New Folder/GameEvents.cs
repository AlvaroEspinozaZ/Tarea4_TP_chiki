
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObject/GameEvent/GameEventM")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListeners> listeners;

    private void OnEnable()
    {
        listeners = new List<GameEventListeners>();
    }

    public void Raise()
    {
        if (listeners != null)
        {
            foreach(GameEventListeners lis in listeners)
            {
                lis.OnEventRaise();
            }
        }
    }

    public void Raise(int i)
    {
        if (listeners != null)
        {
            foreach (GameEventListeners lis in listeners)
            {
                lis.OnEventRaise(i);
            }
        }
    }
    public void Raise(float i)
    {
        if (listeners != null)
        {
            foreach (GameEventListeners lis in listeners)
            {
                lis.OnEventRaise(i);
            }
        }
    }

    public void Register(GameEventListeners listener)
    {
        Debug.Log(listeners);

        listeners.Add(listener);
        Debug.Log("Register");
    }
    public void Unregister(GameEventListeners listener)
    {
        listeners.Remove(listener);
        Debug.Log("UnRegister");

    }
}
