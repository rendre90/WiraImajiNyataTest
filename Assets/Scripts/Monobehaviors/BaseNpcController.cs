using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNpcController : BaseCharacterController
{
    [SerializeField] protected FloatReferenceSO scoreSO;
    [SerializeField] protected float health;
    protected float currentHealth;
    [SerializeField] protected float score;
    float dieTime = 5f;

    void OnEnable(){
        currentHealth = health;
    }
    protected void OnDieObject(MonoBehaviour player){
        player.WaitSeconds(dieTime, ()=>{
            gameObject.SetActive(true);
        });
    }
}
