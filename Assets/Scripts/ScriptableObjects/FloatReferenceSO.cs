using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[CreateAssetMenu(menuName = "MyScriptableObjects/FloatReferenceSO")]
public class FloatReferenceSO : TypeDataEventSO
{
    public float valueRef{
        set{
            var cons = (float)0.0;
            if(!isFlatValue){
                cons = _value;
                _value = value;
            }
            else{
                cons = _flatValue;
                _flatValue = value;
            }
            Value = value;
            DOTween.To(()=> cons, x => cons = x, value, 0.3f)
            .OnUpdate(()=>{
                valueStr = cons.ToString("0.##");
                RaiseUpdate();
            })
            .OnComplete(()=>{
                valueStr = cons.ToString("0.##");
                RaiseUpdate();
            });
            Raise();
        }
        get{
           return isFlatValue ? _flatValue : (float)_value;
        }
    }
    [SerializeField] Unhackable<float> Value = (Unhackable<float>) 0;
    private Unhackable<float> _value = (Unhackable<float>) 0;
    [SerializeField]private bool isFlatValue;
    
    [SerializeField]private float _flatValue = 0;

    private float flatValue{
        set{
            var cons= 0.0f;
            cons = _flatValue;
            _flatValue = value;
            DOTween.To(()=> cons, x => cons = x, value, 0.3f)
            .OnUpdate(()=>{
                valueStr = cons.ToString("0.##");
                RaiseUpdate();
            })
            .OnComplete(()=>{
                valueStr = cons.ToString("0.##");
                RaiseUpdate();
            });
            Value = _flatValue;
            Raise();
        }
        get{
            return valueRef;
        }
    }

  
}
