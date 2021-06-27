using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBehaviourSO : ScriptableObject
{
    
    public abstract void OnRaiseAction(BaseCharacterController baseCharacterController);

    public abstract void OnUpdateAction(BaseCharacterController baseCharacterController);

    public abstract void OnDoneAction(BaseCharacterController baseCharacterController);

    public enum StateAction
    {
        Raise,
        Update,
        Done
    }

}
