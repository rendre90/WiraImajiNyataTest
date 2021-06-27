using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{

    [SerializeField]MoveBehaviourSO playerMoveBehaviour;
    [SerializeField]RotationBehaviourSO playerRotationBehaviour;
    [SerializeField] FireBehaviourSO playerFireBehaviour;
    Vector3 moveDirection = Vector3.zero; 

    // Update is called once per frame
    void Update()
    {
    
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 playerMove = Vector3.zero;
        if(inputHorizontal != 0 || inputVertical != 0){
            Vector3 forward = playerMoveBehaviour.transform.TransformDirection(Vector3.forward);
            Vector3 right = playerMoveBehaviour.transform.TransformDirection(Vector3.right);
            float curSpeedX = Input.GetAxis("Vertical");
            float curSpeedY = Input.GetAxis("Horizontal");
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            playerMove = new Vector3(moveDirection.x, 0, moveDirection.z);
        }

        if(Input.GetButtonDown("Jump")){
            playerMove.y = 1;        
        }

        playerRotationBehaviour.mouseX = Input.GetAxis("Mouse X");
        playerRotationBehaviour.mouseY = Input.GetAxis("Mouse Y");
        playerMoveBehaviour.movementVelocity = playerMove;

        if(Input.GetButtonDown("Fire1")){
            playerFireBehaviour.isTriggerFire= true;
        }
    }
    
}
