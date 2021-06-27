using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDataEventSO : BaseEventSO
{
   protected string valueStr;
   [HideInInspector]public string getValueStr{
      get{
         return valueStr;
      }
   }
   
}
