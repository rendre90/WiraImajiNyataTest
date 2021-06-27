using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : PrefabBaseComponent
{
    BaseCharacterController projectileMaster;
    public BaseCharacterController getProjectileMaster{
        get{
            return projectileMaster;
        }
    }
    [SerializeField] float projectileSpeed;
    float maxDistance;
    Vector3 spawnedPos;
    Rigidbody thisRigidBody;


    public void Init(BaseCharacterController _projectileMaster, float _maxDistance){
        projectileMaster = _projectileMaster;
        spawnedPos = transform.position;
        maxDistance = _maxDistance;
    }
    void Start(){
        thisRigidBody = GetComponent<Rigidbody>();
    }
    void Update(){
        if(Vector3.Distance(spawnedPos, transform.position) < maxDistance){        
            thisRigidBody.velocity = projectileMaster.getProjectileParent.forward * projectileSpeed * Time.deltaTime * 20;
        }else{
            poolingParent.DestroyObj(this);
        }
    }
}
