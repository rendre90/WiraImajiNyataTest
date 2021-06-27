using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : BaseNpcController
{
    void OnTriggerEnter(Collider collider){
        if(collider.tag  == "Projectile" ){
            PlayerProjectile projectile = collider.GetComponent<PlayerProjectile>();
            if(projectile != null){
                if(projectile.getProjectileMaster != this){
                    currentHealth--;
                    if(currentHealth <= 0){
                        gameObject.SetActive(false);
                        OnDieObject(projectile.getProjectileMaster.GetComponent<MonoBehaviour>());    
                    }
                }
            }
            PrefabBaseComponent prefab = collider.GetComponent<PrefabBaseComponent>();
            prefab.poolingParent.DestroyObj(prefab);
            scoreSO.valueRef += score;
        }
    }
}
