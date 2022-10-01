using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent onEventTriggered;
    public UnityGameObjectEvent OnGameObjectEvent;
    public UnityIntEvent OnIntEvent;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    public void OnEventTriggered()
    {
        onEventTriggered.Invoke();
    }
    public void OnGameObjectEventTriggered(GameObject g)
    {
        OnGameObjectEvent.Invoke(g);
    }

    public void OnIntEventTriggered(int i)
    {
        OnIntEvent.Invoke(i);
    }
}

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent < GameObject >
{
    
}

[System.Serializable]
public class UnityIntEvent : UnityEvent<int>
{
    
}
