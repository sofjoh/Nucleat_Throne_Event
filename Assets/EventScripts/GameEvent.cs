using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void TriggerEvent()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
            
        }
    }
    public void TriggerEvent(GameObject g)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnGameObjectEventTriggered(g);
        }
    }
    
    public void TriggerEvent(int input)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnIntEventTriggered(input);
        }
    }
    
    public void AddListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }
    
    public void RemoveListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
