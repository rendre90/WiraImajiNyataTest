using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "MyScriptableObjects/BaseBehaviour/FireBehaviour")]
public class FireBehaviourSO : BaseBehaviourSO
{
    [SerializeField] float fireDistance;
    public UnityEvent fireOnDistance;
    public UnityEvent fireOffDistance;
    
    [SerializeField] LayerMask layerMaskTarget;
    public bool isTriggerFire;
    [SerializeField] PrefabBaseComponent projectilePrefab; 
    [HideInInspector] PoolingManager poolingManager;
    public override void OnDoneAction(BaseCharacterController baseCharacterController)
    {
       
    }

    public override void OnRaiseAction(BaseCharacterController baseCharacterController)
    {
        isTriggerFire = false;
        if(baseCharacterController is PlayerCharacterController){
            PlayerCharacterController playercontroller = (PlayerCharacterController) baseCharacterController;
            fireOnDistance.AddListener(()=> playercontroller.EnemyOnDistance(true));
            fireOffDistance.AddListener(()=> playercontroller.EnemyOnDistance(false));
        }

        if(poolingManager == null){
            GameObject obj = new GameObject("ProjectilePlayer");
            poolingManager =  obj.AddComponent<PoolingManager>();
            projectilePrefab.poolingParent = poolingManager;
            poolingManager.InitialSpawn(projectilePrefab);
        }
    }

    public override void OnUpdateAction(BaseCharacterController baseCharacterController)
    {
        if(Physics.Raycast(baseCharacterController.getProjectileParent.transform.position, baseCharacterController.getProjectileParent.transform.forward, fireDistance, layerMaskTarget)){
            fireOnDistance.Invoke();
            // Debug.Log("EnemyOnDistance");
        }else{
            fireOffDistance.Invoke();
            // Debug.Log("EnemyOffDistance");
        }

        if(isTriggerFire){
            var spawned = poolingManager.SpawnObj(projectilePrefab,  baseCharacterController.getProjectileParent.transform.position, baseCharacterController.getProjectileParent.transform.rotation);
            if(spawned is PlayerProjectile){
                PlayerProjectile projectile = (PlayerProjectile) spawned;
                projectile.Init(baseCharacterController, fireDistance);
            }
            isTriggerFire = false;
        }

    }
}
