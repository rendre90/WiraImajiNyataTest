using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class UiTypeDataReference : BaseEventListener
{
    TextMeshProUGUI objText;
    void Start(){
        objText = GetComponent<TextMeshProUGUI>();
    }

    public void OnValueChanged(){
        TypeDataEventSO typeData = (TypeDataEventSO) baseEvent;
        objText.text = "Score : " +  typeData.getValueStr;       
    }
    
    
}
