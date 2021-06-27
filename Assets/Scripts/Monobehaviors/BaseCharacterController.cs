using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]

public class BaseCharacterController : PrefabBaseComponent
{
    Rigidbody thisRigidBody;

    public Rigidbody getRigidbody{
        get{
            return thisRigidBody;
        }
    }
    [SerializeField] List<BaseBehaviourSO> baseBehavioursList;
    [SerializeField] Transform cameraTransform;
    public Transform getCameraTransform{
        get{
            return cameraTransform;
        }
    }
    [SerializeField] Transform projectileParent;
  
    public Transform getProjectileParent{
        get{
            return projectileParent;
        }
    }

    protected virtual void Start(){
        thisRigidBody = GetComponent<Rigidbody>();
        for(int i = 0; i < baseBehavioursList.Count; i++){
            baseBehavioursList[i].OnRaiseAction(this);
        }
    }

    protected virtual void Update(){
        for(int i = 0; i < baseBehavioursList.Count; i++){
            baseBehavioursList[i].OnUpdateAction(this);
        }
    }

   

}
