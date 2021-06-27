using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BaseEventListener : MonoBehaviour
{
    public BaseEventSO baseEvent;
    [SerializeField] UnityEvent OnRaiseResponse;
    [SerializeField] UnityEvent UpdateResponse;
    [SerializeField] UnityEvent DisableResponse;
    protected virtual void OnEnable()
    { 
        baseEvent.RegisterListener(this); 
    }

    protected virtual void OnDisable()
    { 
        baseEvent.UnregisterListener(this); 
    }

    protected virtual void OnDestroy()
    { 
        baseEvent.UnregisterListener(this); 
    }

    public virtual void OnEventRaised()
    {
        OnRaiseResponse.Invoke(); 
    }

    public virtual void OnUpdateRaised(){
        UpdateResponse.Invoke();
    }

    public virtual void OnDisableResponse(){
        DisableResponse.Invoke();
    }
}
