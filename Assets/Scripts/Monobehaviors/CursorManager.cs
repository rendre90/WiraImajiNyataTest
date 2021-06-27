using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    
    [SerializeField]float mouseInvisibleTime;
    float timerInvisible = 0;
    void Start(){
        timerInvisible = 0;
    }  
    void InvisibleMouse(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void VisibleMouse(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        timerInvisible = 0;
    }

    void Update(){
        timerInvisible += Time.deltaTime;
        if(timerInvisible > mouseInvisibleTime){
            InvisibleMouse();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if(!hasFocus){
            VisibleMouse();
        }
    }
}
