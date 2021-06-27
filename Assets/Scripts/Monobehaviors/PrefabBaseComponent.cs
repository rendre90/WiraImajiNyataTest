using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PrefabBaseComponent : MonoBehaviour
{
    [SerializeField]public  UnityEvent onSpawnObjectEvent;
    [SerializeField]public UnityEvent onSpawnDestroyEvent;
    [HideInInspector]public PoolingManager poolingParent;
    public virtual void OnSpawnObject(){
        onSpawnObjectEvent.Invoke();
    }

    public virtual void OnDestroyObject(){
        onSpawnDestroyEvent.Invoke();
    }

    void OnBecameInvisible(){
       if(poolingParent!= null) poolingParent.DestroyObj(this);
    }

}
