using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptableObjects/BaseBehaviour/RotationBehaviourSO")]
public class RotationBehaviourSO : BaseBehaviourSO
{
    [Range(20, 60)] [SerializeField]float rotationSpeed;
    public float mouseX;
    public float mouseY;

    float timeSpeed;
    float xRotation = 0f;
    [SerializeField] float maxRotY = 90;
    [SerializeField] float minRotY = -90;
    public override void OnDoneAction(BaseCharacterController baseCharacterController){

    }

    public override void OnRaiseAction(BaseCharacterController baseCharacterController){
        mouseX = 0;
        xRotation = 0;
    }

    public override void OnUpdateAction(BaseCharacterController baseCharacterController){
       
       xRotation -= (mouseY * rotationSpeed * Time.deltaTime);
       xRotation = Mathf.Clamp(xRotation, minRotY, maxRotY);
       if(baseCharacterController.getCameraTransform != null){
           baseCharacterController.getCameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
       }
       baseCharacterController.transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);
    }
}
