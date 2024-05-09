using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObject/GameEvent/GameEventInt")]
public class GameEventInt : ScriptableObject
{
    private List<GameEventListeners> listeners;
    public void Raise(int i)
    {
        if (listeners != null)
        {
            foreach (GameEventListeners lis in listeners)
            {
                lis.OnEventRaise();
            }
        }
    }
    public void Register(GameEventListeners listener)
    {
        listeners.Add(listener);
    }
    public void Unregister(GameEventListeners listener)
    {
        listeners.Remove(listener);
    }
}
