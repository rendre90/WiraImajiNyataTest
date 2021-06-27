using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesController : BaseNpcController
{
    void OnTriggerEnter(Collider collision){
        // Debug.Log(collision.transform.tag);
        if(collision.transform.tag  == "Player" ){
            currentHealth--;
            if(currentHealth <= 0){
                gameObject.SetActive(false);   
                OnDieObject(collision.transform.parent.GetComponent<MonoBehaviour>());
            }
            scoreSO.valueRef -= score;
          
        }
    }
}
