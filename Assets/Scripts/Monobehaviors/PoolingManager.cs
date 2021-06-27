using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public List<PrefabBaseComponent> spawnedPrefabList = new List<PrefabBaseComponent>();

    public int initialSpawnedQty = 8;
    public void InitialSpawn(PrefabBaseComponent prefab){
        for(int i = 0; i < initialSpawnedQty; i++){
            PrefabBaseComponent spawnedObj = Instantiate(prefab, transform);
            spawnedObj.gameObject.SetActive(false);
            spawnedPrefabList.Add(spawnedObj);
            if(spawnedObj.poolingParent == null) spawnedObj.poolingParent = this;
        }
    }

    public PrefabBaseComponent SpawnObj(PrefabBaseComponent prefab,Vector3 pos, Quaternion rotation){
        PrefabBaseComponent obj = spawnedPrefabList.Find((x)=>!x.gameObject.activeSelf);
        if(obj == null){
            obj = Instantiate(prefab, pos, rotation, transform);
            spawnedPrefabList.Add(obj);
            if(obj.poolingParent == null) obj.poolingParent = this;
        }
        obj.gameObject.SetActive(true);
        obj.transform.position = pos;
        obj.transform.rotation = rotation;
        obj.OnSpawnObject();
        return obj;   
    }

    public void DestroyObj(PrefabBaseComponent spawnedObj){
        spawnedObj.OnDestroyObject();
        spawnedObj.gameObject.SetActive(false);
    }

    public void DestroyOnSecond(float seconds, PrefabBaseComponent spawnedObj){
        this.WaitSeconds(0.2f, ()=>{
            if(spawnedObj!= null){
                DestroyObj(spawnedObj);
            }
        }); 
    }
    
}
