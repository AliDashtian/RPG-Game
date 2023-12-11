using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = _listeners.Count -1 ; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener gameEventListener)
    {
        _listeners.Add(gameEventListener);
    }
    public void UnregisterListener(GameEventListener gameEventListener)
    {
        _listeners.Remove(gameEventListener);
    }
}
