using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerCharacterController : BaseCharacterController
{ 

    CharacterController characterController;
    public CharacterController getCharacterController{
        get{
            return characterController;
        }
    }
    [SerializeField] SpriteRenderer[] crossHairSR;
    [SerializeField] Color onDistanceColor, offDistanceColor;
    public void EnemyOnDistance(bool isOnDistance){
        for(int i = 0; i < crossHairSR.Length; i++){
            crossHairSR[i].color = isOnDistance ? onDistanceColor : offDistanceColor;
        }
    }

    protected override void Start(){
        characterController = GetComponent<CharacterController>();
        base.Start();
    }

}
