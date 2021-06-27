using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEventSO : ScriptableObject
{
    [SerializeField]protected List<BaseEventListener> listeners = new List<BaseEventListener>();

    public virtual void Raise()
    {
        for(int i = listeners.Count -1; i >= 0; i--)
        listeners[i].OnEventRaised();
    }

    public virtual void RaiseUpdate(){
        // Debug.Log(listeners.Count);
        for(int i = listeners.Count -1; i >= 0; i--)
        listeners[i].OnUpdateRaised();
    }


    public virtual void RegisterListener(BaseEventListener listener)
    { 
        listeners.Add(listener); 
    }

    public virtual void UnregisterListener(BaseEventListener listener)
    { 
        listeners.Remove(listener); 
    }
}
