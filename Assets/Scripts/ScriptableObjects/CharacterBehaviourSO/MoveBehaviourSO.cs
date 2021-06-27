using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObjects/BaseBehaviour/MovementBehaviour")]
public class MoveBehaviourSO : BaseBehaviourSO{
    [Range(20, 250)] [SerializeField] float movementSpeed;
    [Range(1, 10)] [SerializeField] float jumpValue;
    [SerializeField] float gravitasiValue = -9.8f;
    public Unhackable<float> _movementSpeed;
    public Unhackable<float> _jumpValue;
    [HideInInspector]public Vector3 movementVelocity;
    [SerializeField]private Vector3 playerVelocity;
    private bool groundedPlayer;
    [HideInInspector]public Transform transform;

    public override void OnRaiseAction(BaseCharacterController baseCharacterController){
        _movementSpeed = movementSpeed;
        _jumpValue = jumpValue;
        playerVelocity = Vector3.zero;
        transform = baseCharacterController.transform;
    }

    public override void OnUpdateAction(BaseCharacterController baseCharacterController){
        if(baseCharacterController is PlayerCharacterController){
            PlayerCharacterController player = (PlayerCharacterController) baseCharacterController;
            groundedPlayer = player.getCharacterController.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            Vector3 motion = new Vector3(movementVelocity.x, 0, movementVelocity.z);
            player.getCharacterController.Move(motion * Time.deltaTime * movementSpeed);

            if(groundedPlayer && movementVelocity.y > 0){
                playerVelocity.y +=  Mathf.Sqrt(jumpValue * -3.0f * gravitasiValue);
            }
            playerVelocity.y += gravitasiValue * Time.deltaTime;
            player.getCharacterController.Move(playerVelocity * Time.deltaTime);
        }else{
            //TO DO using rigidbody for NPC if they need to be moved
        }
    }

    public override void OnDoneAction(BaseCharacterController baseCharacterController){
        baseCharacterController.getRigidbody.velocity = Vector2.zero;
    }
}
