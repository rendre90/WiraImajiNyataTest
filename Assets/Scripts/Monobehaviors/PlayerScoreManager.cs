using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    [SerializeField] FloatReferenceSO scoreSO;
    void Start(){
        scoreSO.valueRef = 0;
        Debug.Log(scoreSO.valueRef);
    }
}
